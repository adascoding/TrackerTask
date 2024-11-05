using CodeAcademyAPI2.Models;

namespace CodeAcademyAPI2.Database;

public interface IFakeTodoDatabase
{
    List<TodoItem> GetTodoItems();
    TodoItem GetTodoItem(int id);
    void AddTodoItem(TodoItem item);
    bool UpdateTodoItem(TodoItem item);
    bool DeleteTodoItem(int id);
}
