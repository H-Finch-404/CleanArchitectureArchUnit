// using CleanArchitectureArchUnit.Core.Aggregates.ContributorAggregate;
// using CleanArchitectureArchUnit.Infrastructure.Data;
//
// namespace CleanArchitectureArchUnit.Web;
//
// // This class violates the dependency rule between web and infrastructure layers
// internal class ClassThatDependsOnInfrastructureLayer : EfRepository<Contributor>
// {
//   public ClassThatDependsOnInfrastructureLayer(AppDbContext dbContext) : base(dbContext)
//   {
//   }
// }
//
