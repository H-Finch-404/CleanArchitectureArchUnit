using Ardalis.Result;
using CleanArchitectureArchUnit.Core.ProjectAggregate;

namespace CleanArchitectureArchUnit.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
