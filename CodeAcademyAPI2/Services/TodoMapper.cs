using CodeAcademyAPI2.DTOs;
using CodeAcademyAPI2.Models;

namespace CodeAcademyAPI2.Services;

public class TodoMapper : ITodoMapper
{
    public TodoItemResult Map(TodoItem item)
    {
        return new TodoItemResult
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            EndDate = item.EndDate,
            UserId = item.UserId
        };
    }

    public IEnumerable<TodoItemResult> Map(IEnumerable<TodoItem> items)
    {
        return items.Select(Map); 
    }

    public TodoItem Map(TodoItemRequest todoItemRequest)
    {
        return new TodoItem
        {
            Title = todoItemRequest.Title,
            Description = todoItemRequest.Description,
            EndDate= todoItemRequest.EndDate,
            UserId= todoItemRequest.UserId
        };
    }

    public void Project(TodoItem item, TodoItemRequest todoItemRequest)
    {
        item.Title = todoItemRequest.Title;
        item.Description = todoItemRequest.Description;
        item.EndDate = todoItemRequest.EndDate;
        item.UserId = todoItemRequest.UserId;
    }
}
