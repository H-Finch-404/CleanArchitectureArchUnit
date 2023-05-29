using ArchUnitNET.Fluent;
using Ardalis.SmartEnum;
using Ardalis.Specification;
using CleanArchitectureArchUnit.SharedKernel;
using CleanArchitectureArchUnit.SharedKernel.Interfaces;

namespace CleanArchitectureArchUnit.ArchitectureTests.DependencyInversionTests;

using static ArchRuleDefinition;

[TestFixture]
public class InfrastructureLayerDependencyInversionTests : ArchitectureTestBase
{
  [Test]
  public void WebLayer_ShouldOnly_DependOn_Abstractions_InCoreLayer_OrDomainEntities()
  {
    var allowedCoreClasses = Types().That()
      .ResideInNamespace("CleanArchitectureArchUnit.Core.Aggregates", true)
      .And()
      .AreAssignableTo(typeof(IAggregateRoot), typeof(EntityBase), typeof(SmartEnum<>), typeof(ValueObject),
        typeof(Specification<>))
      .Or()
      .AreEnums()
      .As("Public Core Classes");

    var coreInterfaces = Types().That()
      .Are(CoreLayer)
      .And()
      .Are(Interfaces().That().ArePublic())
      .As("Public Core Interfaces");

    var sharedKernelTypes = Types().That()
      .ResideInNamespace("CleanArchitectureArchUnit.SharedKernel", true);

    var rule = Types().That().Are(InfrastructureLayer).And()
      .DependOnAny(CoreLayer)
      .Should()
      .OnlyDependOn(Types().That()
        .Are(allowedCoreClasses)
        .Or()
        .Are(coreInterfaces)
        .Or()
        .Are(sharedKernelTypes)
        .Or()
        .Are(InfrastructureLayer));

    Check(rule);
  }
}
