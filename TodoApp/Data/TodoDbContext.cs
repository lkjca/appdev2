using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
    public class TodoItem
{
    public int Id { get; set; }
    public string Task { get; set; } = string.Empty;
    public bool IsDone { get; set; }
    public IdentityUser? Owner { get; set; }
    public DateTime DueDate { get; set; }
}
}