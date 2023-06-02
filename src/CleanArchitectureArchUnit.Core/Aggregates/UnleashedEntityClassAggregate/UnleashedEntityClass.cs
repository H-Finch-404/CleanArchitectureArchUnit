using CleanArchitectureArchUnit.SharedKernel;
using CleanArchitectureArchUnit.SharedKernel.Interfaces;

namespace CleanArchitectureArchUnit.Core.Aggregates.UnleashedEntityClassAggregate;

public class UnleashedEntityClass : EntityBase, IAggregateRoot
{
}

public class SuperUnleashedEntityClass : UnleashedEntityClass
{
  
}

public class NamingRulesAreImportantEntityClass : UnleashedEntityClass
{
  
}
