using ArchUnitNET.Fluent;
using CleanArchitectureArchUnit.Core.Aggregates.UnleashedEntityClassAggregate;
using CleanArchitectureArchUnit.Core.NamingRulesTestsClasses;
using CleanArchitectureArchUnit.SharedKernel;

namespace CleanArchitectureArchUnit.ArchitectureTests.NamingRulesTests;

using static ArchRuleDefinition;

[TestFixture]
public class CoreLayerNamingRulesTests : ArchitectureTestBase
{
  [Test]
  public void CoreLayerDomainEvents_ShouldHave_Name_EndingWithEvent()
  {
    IArchRule rule = Types().That().Are(CoreLayer)
      .And().AreAssignableTo(typeof(DomainEventBase))
      .Should().HaveNameEndingWith("Event");

    Check(rule);
  }

  [Test]
  [TestCase(typeof(Duck))]
  public void Inheritors_InInheritanceChainOfType_ShouldHave_Name_EndingWith_InheritedTypeName(Type superType)
  {
    var rule = DirectInheritorsOfType_ShouldRecursivelyHave_NameEndingWithInheritedTypeName(superType);

    Check(rule);
  }
  private static IArchRule DirectInheritorsOfType_ShouldRecursivelyHave_NameEndingWithInheritedTypeName(Type type)
  {
    var directInheritors = GetDirectInheritors(type);
    IArchRule rule = Types().That().Are(directInheritors)
      .As($"Direct inheritors of {type.Name}")
      .Should()
      .HaveNameEndingWith(type.Name);

    directInheritors.ForEach(
      subType =>
      {
        rule = rule.And(DirectInheritorsOfType_ShouldRecursivelyHave_NameEndingWithInheritedTypeName(subType));
      });
    return rule;
  }
  private static List<Type> GetDirectInheritors(Type superType)
  {
    return superType.Assembly.GetTypes().Where(type => type.BaseType == superType).ToList();
  }


  [Test]
  public void UnleashedEntityClass_ShouldHave_ToStringMethod()
  {
    IArchRule rule = Classes().That().Are(CoreLayer)
      .And().AreAssignableTo(typeof(UnleashedEntityClass))
      .Should().HaveMethodMemberWithName("ToString");

    Check(rule);
  }
}
