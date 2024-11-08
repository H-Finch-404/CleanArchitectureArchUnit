﻿using ArchUnitNET.Fluent;

namespace CleanArchitectureArchUnit.ArchitectureTests.LayerDependencyTests;

using static ArchRuleDefinition;

[TestFixture]
public class CoreLayerDependencyTests : ArchitectureTestBase
{
  [Test]
  public void CoreLayer_ShouldNot_DependOn_InfrastructureLayer()
  {
    IArchRule coreLayerShouldNotDependOnInfrastructureLayerRule =
      Types().That().Are(CoreLayer).Should().NotDependOnAnyTypesThat().Are(InfrastructureLayer);

    Check(coreLayerShouldNotDependOnInfrastructureLayerRule);
  }

  [Test]
  public void CoreLayer_ShouldNot_DependOn_WebLayer()
  {
    IArchRule coreLayerShouldNotDependOnWebLayerRule =
      Types().That().Are(CoreLayer).Should().NotDependOnAnyTypesThat().Are(WebLayer);

    Check(coreLayerShouldNotDependOnWebLayerRule);
  }
}
