using Microsoft.EntityFrameworkCore;
using TO_DO_LIST_WepAPI.Data;
using TO_DO_LIST_WepAPI.Models.DTOs;
using TO_DO_LIST_WepAPI.Models.Entities;
using TO_DO_LIST_WepAPI.Models.TaskItemDTO;

namespace TO_DO_LIST_WepAPI.Services;

public class TodoService : ITodoService
{
    private readonly TodoDbContext _context;
    public TodoService(TodoDbContext context) => _context = context;
    public async Task<List<TodoDTO>> GetAllAsync()
    {
        var todoItems = await _context.Todo_Items
            .OrderBy(item => item.CreatedAt)
            .ToListAsync();

        var todoDtos = new List<TodoDTO>();

        foreach (var item in todoItems)
        {
            todoDtos.Add(MapToDto(item));
        }

        return todoDtos;
    }
    public async Task<TodoDTO> GetByIdAsync(int id)
    {
        var todoItem = await _context.Todo_Items.FindAsync(id);

        if (todoItem == null)
            return null;

        return MapToDto(todoItem);
    }
    public async Task<TodoDTO> CreateAsync(CreateTodoItemDTO createTodo)
    {
        ValidateTodoItem(createTodo.Title, createTodo.Description);

        var todoItem = new TodoItem
        {
            Title = createTodo.Title.Trim(),
            Description = createTodo.Description.Trim(),
            CreatedAt = DateTime.UtcNow,
            IsCompleted = false
        };

        _context.Todo_Items.Add(todoItem);
        await _context.SaveChangesAsync();

        return MapToDto(todoItem);
    }

    public async Task<TodoDTO> UpdateAsync(int id, UpdateTodoItemDTO updateTodo)
    {
        var todoItem = await _context.Todo_Items.FindAsync(id);

        if (todoItem == null)
            return null;

        ValidateTodoItem(updateTodo.Title, updateTodo.Description);

        todoItem.Title = updateTodo.Title.Trim();
        todoItem.Description = updateTodo.Description.Trim();
        todoItem.IsCompleted = updateTodo.IsCompleted;

        await _context.SaveChangesAsync();

        return MapToDto(todoItem);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var todoItem = await _context.Todo_Items.FindAsync(id);

        if (todoItem == null)
            return false;

        _context.Todo_Items.Remove(todoItem);
        await _context.SaveChangesAsync();

        return true;
    }

    // Método privado para centralizar validações
    private void ValidateTodoItem(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required");

        if (title.Length > 100)
            throw new ArgumentException("Title must be less than 100 characters");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required");
    }

    // Método privado para eliminar código repetido 
    private TodoDTO MapToDto(TodoItem item)
    {
        return new TodoDTO
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            CreatedAt = item.CreatedAt,
            IsCompleted = item.IsCompleted
        };
    }
}