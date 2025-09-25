using Microsoft.EntityFrameworkCore;
using TO_DO_LIST_WepAPI.Models.Entities;

namespace TO_DO_LIST_WepAPI.Data;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> Todo_Items { get; set; }
    public TodoDbContext(DbContextOptions options) : base(options) { }
   
}
