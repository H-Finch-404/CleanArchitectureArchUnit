using Ardalis.Specification;
using CleanArchitectureArchUnit.Core.ContributorAggregate;

namespace CleanArchitectureArchUnit.Core.ProjectAggregate.Specifications;

public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
