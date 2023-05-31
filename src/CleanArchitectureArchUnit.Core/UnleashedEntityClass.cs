using CleanArchitectureArchUnit.SharedKernel;
using CleanArchitectureArchUnit.SharedKernel.Interfaces;

namespace CleanArchitectureArchUnit.Core;

// This class will violate the test/architectural rule
// AggregateRoots_Should_Reside_InCoreLayer_And_AggregatesNamespace

public class UnleashedEntityClass :  EntityBase, IAggregateRoot
{ 
  public UnleashedEntityClass()
  {
   
  }
}
