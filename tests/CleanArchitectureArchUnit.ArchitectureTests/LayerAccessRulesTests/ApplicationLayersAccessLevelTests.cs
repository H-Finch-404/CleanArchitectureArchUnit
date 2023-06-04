using ArchUnitNET.Fluent;

namespace CleanArchitectureArchUnit.ArchitectureTests.LayerAccessRulesTests;

using static ArchRuleDefinition;
[TestFixture]
public class ApplicationLayersAccessLevelTests : ArchitectureTestBase
{

  [Test]
  public void TypesOfInfrastructureLayer_ShouldHave_AccessLevel_EqualToOrStricterThanInternal()
  {
    IArchRule rule = Types().That().Are(InfrastructureLayer)
      .Should().BeInternal()
      .OrShould().BePrivate()
      .OrShould().BePrivateProtected();
    
    Check(rule);
  }
}
