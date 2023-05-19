using Autofac;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureArchUnit.SharedKernel;

public abstract class ProjectModule : Module
{
  protected readonly IConfiguration Configuration;
  protected ProjectModule(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  protected override void Load(ContainerBuilder builder)
  {
    RegisterCommonDependencies(builder);
    if (IsDevelopment)
    {
      RegisterDevelopmentOnlyDependencies(builder);
    }
    else
    {
      RegisterProductionOnlyDependencies(builder);
    }
  }

  public bool IsDevelopment { get; set; }
  
  protected virtual void RegisterCommonDependencies(ContainerBuilder builder) {}

  protected virtual void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder) {}
  
  protected virtual void RegisterProductionOnlyDependencies(ContainerBuilder builder) {}
}
