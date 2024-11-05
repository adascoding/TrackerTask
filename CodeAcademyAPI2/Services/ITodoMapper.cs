using CodeAcademyAPI2.DTOs;
using CodeAcademyAPI2.Models;

namespace CodeAcademyAPI2.Services
{
    public interface ITodoMapper
    {
        IEnumerable<TodoItemResult> Map(IEnumerable<TodoItem> items);
        TodoItemResult Map(TodoItem item);
        TodoItem Map(TodoItemRequest todoItemRequest);
        void Project(TodoItem item, TodoItemRequest todoItemRequest);
    }
}
