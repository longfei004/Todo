using Microsoft.EntityFrameworkCore;

namespace Todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext (
            DbContextOptions<TodoContext> options) : base (options)
        { }

        public DbSet<Todo.Models.TodoItem> TodoItems { get; set; }  
    }
}