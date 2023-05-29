using Ardalis.Specification;
using CleanArchitectureArchUnit.Core.Aggregates.ContributorAggregate;

namespace CleanArchitectureArchUnit.Core.Aggregates.ProjectAggregate.Specifications;

public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
