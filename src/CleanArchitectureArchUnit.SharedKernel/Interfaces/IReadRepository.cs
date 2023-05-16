using Ardalis.Specification;

namespace CleanArchitectureArchUnit.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
