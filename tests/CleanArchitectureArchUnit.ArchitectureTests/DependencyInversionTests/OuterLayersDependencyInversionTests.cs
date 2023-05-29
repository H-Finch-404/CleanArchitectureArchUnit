using System.Collections;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using Ardalis.SmartEnum;
using Ardalis.Specification;
using CleanArchitectureArchUnit.SharedKernel;
using CleanArchitectureArchUnit.SharedKernel.Interfaces;

namespace CleanArchitectureArchUnit.ArchitectureTests.DependencyInversionTests;

using static ArchRuleDefinition;

[TestFixture]
public class OuterLayersDependencyInversionTests : ArchitectureTestBase
{
  private const string TopLevelNamespace = nameof(CleanArchitectureArchUnit);

  [Test]
  [TestCaseSource(typeof(OuterLayersTestCaseSource))]
  public void OuterLayer_ShouldOnly_DependOn_AbstractionsOrDomainEntities_InCoreLayer_And_SharedKernel(IObjectProvider<IType> outerLayer)
  {
    var allowedCoreClasses = Types().That()
      .ResideInNamespace($"{TopLevelNamespace}.Core.Aggregates", true)
      .And()
      .AreAssignableTo(typeof(IAggregateRoot), typeof(EntityBase),
        typeof(SmartEnum<>), 
        typeof(ValueObject),
        typeof(Specification<>))
      .Or()
      .AreEnums()
      .As("Public Core Classes");

    var coreInterfaces = Types().That().Are(CoreLayer)
      .And().Are(Interfaces().That().ArePublic())
      .As("Public Core Interfaces");

    // Types in the SharedKernel project  
    var sharedKernelTypes = Types().That()
      .ResideInNamespace($"{TopLevelNamespace}.SharedKernel", true);

    IArchRule rule = Types().That().Are(outerLayer)
      .And().DependOnAny(CoreLayer)
      .Should().OnlyDependOn(Types().That()
        .Are(allowedCoreClasses)
        .Or().Are(coreInterfaces)
        .Or().Are(sharedKernelTypes)
        .Or().Are(outerLayer))
      .Because(
        $"An outer layer can only: depend on itself, " +
        $"abstractions and specific domain entities from the {CoreLayer} " +
        $"and types defined in the SharedKernel project");

    Check(rule);
  }
  private sealed class OuterLayersTestCaseSource : IEnumerable
  {
    public IEnumerator GetEnumerator()
    {
      yield return WebLayer;
      yield return InfrastructureLayer;
    }
  }
}
