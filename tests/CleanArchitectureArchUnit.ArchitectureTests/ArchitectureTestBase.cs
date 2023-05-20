using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using CleanArchitectureArchUnit.Core;
using CleanArchitectureArchUnit.Infrastructure;
using Assembly = System.Reflection.Assembly;

using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace CleanArchitectureArchUnit.ArchitectureTests;
public abstract class ArchitectureTestBase
{
  // Declare layer assemblies
  private static readonly Assembly _webLayerAssembly = typeof(Program).Assembly;
  private static readonly Assembly _infrastructureLayerAssembly = typeof(DefaultInfrastructureModule).Assembly;
  private static readonly Assembly _coreLayerAssembly = typeof(DefaultCoreModule).Assembly;

  // Initialize array of specified assemblies for reusablity
  protected static readonly Assembly[] Assemblies = { _webLayerAssembly, _infrastructureLayerAssembly, _coreLayerAssembly };
  
  // Initialize the architecture using specified assemblies
  protected readonly Architecture Architecture = new ArchLoader().LoadAssemblies(Assemblies).Build();
  
  // Declare reusable layer objects
  protected static readonly IObjectProvider<IType> WebLayer = Types().That().ResideInAssembly(_webLayerAssembly).As("Web Layer");
  protected static readonly IObjectProvider<IType> CoreLayer = Types().That().ResideInAssembly(_coreLayerAssembly).As("Core Layer");
  protected static readonly IObjectProvider<IType> InfrastructureLayer = Types().That().ResideInAssembly(_infrastructureLayerAssembly).As("Infrastructure Layer");
  
}
