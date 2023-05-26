// using CleanArchitectureArchUnit.Infrastructure;
// using Microsoft.Extensions.Configuration;
//
// namespace CleanArchitectureArchUnit.Core;
//
// // This class will violate the Dependency Rule
// public class ClassThatDependsOnInfrastructureLayer : DefaultInfrastructureModule
// {
//   public ClassThatDependsOnInfrastructureLayer(IConfiguration configuration) : base(configuration)
//   {
//   }
// }

// 1. COMMENT (OR TEMPORARILY REMOVE) CLASSES IN INFRASTRUCTURE LAYER THAT REFERENCE THE CORE LAYER & COMMENT INFRA MODULE SETUP IN BOOTSTRAP PROJECT
// 2. REMOVE THE REFERENCE FROM INFRASTRUCTURE TO CORE
// 3. ADD A REFERENCE FROM CORE TO INFRASTRUCTURE
// 4. CREATE A CLASS THAT REFERENCES THE INFRASTRUCTURE LAYER (LIKE THIS ONE)
// 5. SOME OF THE ARCHITECTURE TESTS IN THE CORE LAYER WILL FAIL
