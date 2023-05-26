using ArchUnitNET.Fluent;

namespace CleanArchitectureArchUnit.ArchitectureTests.LayerDependencyTests;

using static ArchRuleDefinition;

[TestFixture]
public class WebLayerDependencyTests : ArchitectureTestBase
{
  [Test]
  public void WebLayer_ShouldNot_DependOn_InfrastructureLayer()
  {
    IArchRule webLayerShouldNotDependOnInfrastructureLayerRule =
      Types().That().Are(WebLayer).Should().NotDependOnAnyTypesThat().Are(InfrastructureLayer);

    Check(webLayerShouldNotDependOnInfrastructureLayerRule);
  }
}
