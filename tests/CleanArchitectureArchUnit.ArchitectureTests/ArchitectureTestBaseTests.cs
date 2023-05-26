namespace CleanArchitectureArchUnit.ArchitectureTests;

// This class performs some basic validation tests to ensure the architecture loaded properly
[TestFixture]
public class ArchitectureTestBaseTests : ArchitectureTestBase
{
  [Test]
  public void Architecture_ShouldNot_BeNull()
  {
    Assert.That(Architecture, Is.Not.Null);
  }

  [Test]
  public void Architecture_ShouldHave_AssemblyCount_EqualTo_CountOfSpecifiedAssemblies()
  {
    Assert.That(Architecture.Assemblies.Count(), Is.EqualTo(Assemblies.Length));
  }
}
