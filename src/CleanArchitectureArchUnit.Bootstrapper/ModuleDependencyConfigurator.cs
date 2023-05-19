using Autofac;
using CleanArchitectureArchUnit.Core;
using CleanArchitectureArchUnit.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureArchUnit.Bootstrapper;

public static class ModuleDependencyConfigurator
{
  public static void Configure(ContainerBuilder builder,IConfiguration configuration)
  {
    builder.RegisterModule(new DefaultCoreModule(configuration));
    builder.RegisterModule(new DefaultInfrastructureModule(configuration));
  }
}
