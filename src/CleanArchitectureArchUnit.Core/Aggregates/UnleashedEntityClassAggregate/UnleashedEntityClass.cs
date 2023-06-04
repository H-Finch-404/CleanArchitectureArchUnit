using CleanArchitectureArchUnit.SharedKernel;
using CleanArchitectureArchUnit.SharedKernel.Interfaces;

namespace CleanArchitectureArchUnit.Core.Aggregates.UnleashedEntityClassAggregate;

public class UnleashedEntityClass : EntityBase, IAggregateRoot
{
  public override string ToString()
  {
    return $"Hello from {nameof(UnleashedEntityClass)}!";
  }
}

public class SuperUnleashedEntityClass : UnleashedEntityClass
{
  
}

public class NamingRulesAreImportantEntityClass : UnleashedEntityClass
{
  
}
