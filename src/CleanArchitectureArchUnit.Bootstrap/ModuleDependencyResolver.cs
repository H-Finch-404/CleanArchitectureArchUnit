using Autofac;
using CleanArchitectureArchUnit.Core;
// using CleanArchitectureArchUnit.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureArchUnit.Bootstrap;

public static class ModuleDependencyResolver
{
  public static void RegisterModules(ContainerBuilder containerBuilder, IConfiguration configuration)
  {
    containerBuilder.RegisterModule(new DefaultCoreModule(configuration));
    // containerBuilder.RegisterModule(new DefaultInfrastructureModule(configuration));
  }
}
