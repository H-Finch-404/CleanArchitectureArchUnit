using Ardalis.Result;

namespace CleanArchitectureArchUnit.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(int contributorId);
}
