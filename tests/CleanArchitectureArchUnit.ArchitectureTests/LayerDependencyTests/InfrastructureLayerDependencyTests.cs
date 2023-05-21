using ArchUnitNET.Fluent;
using ArchUnitNET.NUnit;

namespace CleanArchitectureArchUnit.ArchitectureTests.LayerDependencyTests;

using static ArchRuleDefinition;
[TestFixture]
public class InfrastructureLayerDependencyTests : ArchitectureTestBase
{
  
  [Test]
  public void InfrastructureLayer_ShouldNot_DependOn_WebLayer()
  {
    IArchRule infrastructureLayerShouldNotDependOnWebLayerRule =
      Types().That().Are(InfrastructureLayer).Should().NotDependOnAnyTypesThat().Are(WebLayer);

    Check(infrastructureLayerShouldNotDependOnWebLayerRule);
  }
}
