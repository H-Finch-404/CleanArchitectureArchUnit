using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.NUnit;
using CleanArchitectureArchUnit.Core;
using CleanArchitectureArchUnit.Infrastructure;
using CleanArchitectureArchUnit.SharedKernel;
using Assembly = System.Reflection.Assembly;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

[SetUpFixture]
// ReSharper disable once CheckNamespace
#pragma warning disable CA1050
public abstract class ArchitectureTestBase
#pragma warning restore CA1050
{
  // Declare layer assemblies
  private static readonly Assembly _webLayerAssembly = typeof(Program).Assembly;
  private static readonly Assembly _infrastructureLayerAssembly = typeof(DefaultInfrastructureModule).Assembly;
  private static readonly Assembly _coreLayerAssembly = typeof(DefaultCoreModule).Assembly;
  private static readonly Assembly _sharedKernelAssembly = typeof(ProjectModule).Assembly;

  // Initialize array of specified assemblies for reusablity
  protected static readonly Assembly[] Assemblies =
  {
    _webLayerAssembly, _infrastructureLayerAssembly, _coreLayerAssembly,_sharedKernelAssembly
  };

  // Declare reusable layer objects
  protected static readonly IObjectProvider<IType> WebLayer =
    Types().That().ResideInAssembly(_webLayerAssembly).As("Web (Presentation) Layer");

  protected static readonly IObjectProvider<IType> CoreLayer =
    Types().That().ResideInAssembly(_coreLayerAssembly).As("Core Layer");

  protected static readonly IObjectProvider<IType> InfrastructureLayer =
    Types().That().ResideInAssembly(_infrastructureLayerAssembly).As("Infrastructure Layer");

  protected Architecture Architecture = null!;

  [OneTimeSetUp]
  public void LoadArchitecture()
  {
    // Initialize the architecture using specified assemblies
    Architecture = new ArchLoader().LoadAssemblies(Assemblies).Build();
  }
  protected void Check(IArchRule rule)
  {
    // Check whether the architecture conforms to the given rule
    rule.Check(Architecture);
  }
}
