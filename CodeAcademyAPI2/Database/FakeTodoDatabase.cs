using CodeAcademyAPI2.Models;

namespace CodeAcademyAPI2.Database
{
    public class FakeTodoDatabase : IFakeTodoDatabase
    {
        private readonly List<TodoItem> _todoItems;

        public FakeTodoDatabase()
        {
            _todoItems = new List<TodoItem>
            {
                new TodoItem { Id = 1, Title = "Learn C#", Description = "Complete C# basics", EndDate = DateTime.Now.AddDays(7), UserId = "user1" },
                new TodoItem { Id = 2, Title = "Build API", Description = "Develop a REST API with .NET", EndDate = DateTime.Now.AddDays(10), UserId = "user2" },
                new TodoItem { Id = 3, Title = "Frontend Design", Description = "Design UI in React", EndDate = DateTime.Now.AddDays(14), UserId = "user1" },
                new TodoItem { Id = 4, Title = "Write Tests", Description = "Create unit tests for API", EndDate = DateTime.Now.AddDays(5), UserId = "user3" },
                new TodoItem { Id = 5, Title = "Database Setup", Description = "Configure SQL database", EndDate = DateTime.Now.AddDays(20), UserId = "user2" },
                new TodoItem { Id = 6, Title = "Deploy App", Description = "Deploy API to Azure", EndDate = DateTime.Now.AddDays(25), UserId = "user1" },
                new TodoItem { Id = 7, Title = "Refactor Code", Description = "Clean up and optimize code", EndDate = DateTime.Now.AddDays(15), UserId = "user3" },
                new TodoItem { Id = 8, Title = "Documentation", Description = "Write project documentation", EndDate = DateTime.Now.AddDays(30), UserId = "user2" },
                new TodoItem { Id = 9, Title = "Learn EF Core", Description = "Practice Entity Framework Core", EndDate = DateTime.Now.AddDays(12), UserId = "user3" },
                new TodoItem { Id = 10, Title = "Implement Auth", Description = "Add authentication to API", EndDate = DateTime.Now.AddDays(18), UserId = "user1" }
            };
        }

        public List<TodoItem> GetTodoItems()
        {
            return _todoItems;
        }

        public TodoItem GetTodoItem(int id)
        {
            return _todoItems.FirstOrDefault(item => item.Id == id);
        }

        public void AddTodoItem(TodoItem item)
        {
            item.Id = _todoItems.Count > 0 ? _todoItems.Max(x => x.Id) + 1 : 1;
            _todoItems.Add(item);
        }

        public bool UpdateTodoItem(TodoItem item)
        {
            var existingItem = _todoItems.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Title = item.Title;
                existingItem.Description = item.Description;
                existingItem.EndDate = item.EndDate;
                existingItem.UserId = item.UserId;
                return true;
            }
            return false;
        }

        public bool DeleteTodoItem(int id)
        {
            var item = _todoItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _todoItems.Remove(item);
                return true;
            }
            return false;
        }
    }
}
