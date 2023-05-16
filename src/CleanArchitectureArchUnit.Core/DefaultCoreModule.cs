using Autofac;
using CleanArchitectureArchUnit.Core.Interfaces;
using CleanArchitectureArchUnit.Core.Services;

namespace CleanArchitectureArchUnit.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();
  }
}
