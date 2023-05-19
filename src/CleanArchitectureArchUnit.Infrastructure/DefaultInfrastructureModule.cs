using System.Reflection;
using Autofac;
using CleanArchitectureArchUnit.Core.Interfaces;
using CleanArchitectureArchUnit.Core.ProjectAggregate;
using CleanArchitectureArchUnit.Infrastructure.Data;
using CleanArchitectureArchUnit.SharedKernel;
using CleanArchitectureArchUnit.SharedKernel.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace CleanArchitectureArchUnit.Infrastructure;

public class DefaultInfrastructureModule : ProjectModule
{
  private readonly List<Assembly> _assemblies = new List<Assembly>();

  public DefaultInfrastructureModule(IConfiguration configuration) : base(configuration)
  {
  }
  
  protected override void RegisterCommonDependencies(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
      .As(typeof(IRepository<>))
      .As(typeof(IReadRepository<>))
      .InstancePerLifetimeScope();
    
    builder
      .RegisterType<Mediator>()
      .As<IMediator>()
      .InstancePerLifetimeScope();

    builder
      .RegisterType<DomainEventDispatcher>()
      .As<IDomainEventDispatcher>()
      .InstancePerLifetimeScope();
    
    builder.Register(c =>
      {
        string? connectionString = Configuration.GetConnectionString("SqliteConnection");  //Configuration.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(connectionString);
        return new AppDbContext(optionsBuilder.Options,c.Resolve<IDomainEventDispatcher>());
      })
      .As<AppDbContext>()
      .InstancePerLifetimeScope();
    
    builder
      .RegisterType<SeedData>()
      .As<IStartable>()
      .SingleInstance();

    //builder.Register<ServiceFactory>(context =>
    //{
    //  var c = context.Resolve<IComponentContext>();

    //  return t => c.Resolve(t);
    //});

    // var mediatrOpenTypes = new[]
    // {
    //   typeof(IRequestHandler<,>), 
    //   typeof(IRequestExceptionHandler<,,>), 
    //   typeof(IRequestExceptionAction<,>),
    //   typeof(INotificationHandler<>),
    // };
    //
    // foreach (var mediatrOpenType in mediatrOpenTypes)
    // {
    //   builder
    //     .RegisterAssemblyTypes(_assemblies.ToArray())
    //     .AsClosedTypesOf(mediatrOpenType)
    //     .AsImplementedInterfaces();
    // }
  }

  protected override void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
  {
    // NOTE: Add any development only services here
    builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
      .InstancePerLifetimeScope();
  }

  protected override void RegisterProductionOnlyDependencies(ContainerBuilder builder)
  {
    // NOTE: Add any production only services here
    builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
      .InstancePerLifetimeScope();
  }
}
