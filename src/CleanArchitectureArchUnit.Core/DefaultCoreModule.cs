using Autofac;
using CleanArchitectureArchUnit.Core.Interfaces;
using CleanArchitectureArchUnit.Core.Services;
using CleanArchitectureArchUnit.SharedKernel;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureArchUnit.Core;

public class DefaultCoreModule : ProjectModule
{
  public DefaultCoreModule(IConfiguration configuration) : base(configuration)
  {
  }

  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();
  }

  
}
