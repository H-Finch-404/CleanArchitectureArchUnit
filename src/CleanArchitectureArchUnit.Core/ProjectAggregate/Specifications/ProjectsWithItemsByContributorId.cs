﻿using Ardalis.Specification;

namespace CleanArchitectureArchUnit.Core.ProjectAggregate.Specifications;

public class ProjectsWithItemsByContributorIdSpec : Specification<Project>, ISingleResultSpecification
{
  public ProjectsWithItemsByContributorIdSpec(int contributorId)
  {
    Query
        .Where(project => project.Items.Any(item => item.ContributorId == contributorId))
        .Include(project => project.Items);
  }
}