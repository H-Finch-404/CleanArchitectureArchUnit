// using CleanArchitectureArchUnit.Core.Services;
//
// // This class depends on a specific implementation of IDeleteContributorService which violates Dependency Inversion
// public class ClassThatDependsOnForbiddenCoreClass
// {
//   private readonly DeleteContributorService _deleteContributorService;
//
//   public ClassThatDependsOnForbiddenCoreClass(DeleteContributorService deleteContributorService)
//   {
//     _deleteContributorService = deleteContributorService;
//   }
// }
