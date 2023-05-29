using CleanArchitectureArchUnit.SharedKernel;

namespace CleanArchitectureArchUnit.Core.Aggregates.ProjectAggregate.Events;

public class ToDoItemCompletedEvent : DomainEventBase
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
