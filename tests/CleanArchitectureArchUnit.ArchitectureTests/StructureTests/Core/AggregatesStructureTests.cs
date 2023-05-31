using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Conditions;
using CleanArchitectureArchUnit.SharedKernel.Interfaces;

namespace CleanArchitectureArchUnit.ArchitectureTests.StructureTests.Core;

using static ArchRuleDefinition;

[TestFixture]
public class AggregatesStructureTests : ArchitectureTestBase
{
  [Test]
  public void AggregateRoots_Should_Reside_InCoreLayer_And_AggregatesNamespace()
  {
    var concreteAggregateRoots = Classes().That()
      .AreAssignableTo(typeof(IAggregateRoot))
      .And()
      .AreNotAbstract();

    const string namespacePrefix = $"{nameof(CleanArchitectureArchUnit)}.Core.Aggregates.";
    const string namespacePostFix = "Aggregate";

    IArchRule rule = concreteAggregateRoots
      .Should().Be(CoreLayer).AndShould().ResideInAssembly(_coreLayerAssembly)
      .AndShould().FollowCustomCondition(@class =>
      {
        var expectedFullNamespaceName = $"{namespacePrefix}{@class.Name}{namespacePostFix}";
        
        return new ConditionResult(@class, @class.Namespace.FullName.Equals(expectedFullNamespaceName),
          $"was not defined in " +
          $"{nameof(CleanArchitectureArchUnit)}.Core.Aggregates.{@class.Name}Aggregate");
      }, "should reside in correct namespace");

    Check(rule);
  }
}
