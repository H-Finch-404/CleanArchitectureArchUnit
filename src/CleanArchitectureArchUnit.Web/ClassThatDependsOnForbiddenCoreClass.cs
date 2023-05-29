// using CleanArchitectureArchUnit.Core.Aggregates.ContributorAggregate;
// using CleanArchitectureArchUnit.Core.Services;
// using CleanArchitectureArchUnit.SharedKernel.Interfaces;
// using MediatR;
//
// namespace CleanArchitectureArchUnit.Web;
//
//
// public class ClassThatDependsOnForbiddenCoreClass : DeleteContributorService
// {
//   public ClassThatDependsOnForbiddenCoreClass(IRepository<Contributor> repository, IMediator mediator) : base(repository, mediator)
//   {
//   }
// }
//
// public class ClassThat
// {
//   private readonly DeleteContributorService _deleteContributorService;
//
//   public ClassThat(DeleteContributorService deleteContributorService)
//   {
//     _deleteContributorService = deleteContributorService;
//   }
// }
//
// // public class Test : IConfiguration
// // {
// //   public ClassThatDependsOnForbiddenCoreClass(IConfiguration configuration) : base(configuration)
// //   {
// //   }
// // }
