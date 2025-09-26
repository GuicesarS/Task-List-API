using Microsoft.EntityFrameworkCore;
using TO_DO_LIST_WepAPI.Data;
using TO_DO_LIST_WepAPI.Models.DTOs;
using TO_DO_LIST_WepAPI.Models.Entities;
using TO_DO_LIST_WepAPI.Models.TaskItemDTO;

namespace TO_DO_LIST_WepAPI.Services;

public class TodoService : ITodoService
{
    private readonly TodoDbContext _context; // Preciso acessar o banco de dados
    public TodoService(TodoDbContext context) => _context = context;
    public async Task<List<TodoDTO>> GetAllAsync()
    {
        var todos = await _context.Todo_Items
            .OrderBy(create => create.CreatedAt)
            .ToListAsync();

        var listTodoDTOs = new List<TodoDTO>(); // dados que vou retornar

        foreach (var todo in todos)
        {
            listTodoDTOs.Add(new TodoDTO
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                CreatedAt = todo.CreatedAt,
                IsCompleted = todo.IsCompleted
            });       
        }

        return listTodoDTOs;
    }
    public async Task<TodoDTO> GetByIdAsync(int id)
    {
        var todoId = await _context.Todo_Items.FindAsync(id);

        if(todoId == null)
            return null;

        return new TodoDTO
        {
            Id = todoId.Id,
            Title = todoId.Title,
            Description = todoId.Description,
            CreatedAt = todoId.CreatedAt,
            IsCompleted = todoId.IsCompleted
        };
    }
    public async Task<TodoDTO> CreateAsync(CreateTodoItemDTO createTodo)
    {
        // Antes de criar, validar os dados

        if (string.IsNullOrWhiteSpace(createTodo.Title))
            throw new ArgumentException("Title is required");

        if (createTodo.Title.Length > 100)
            throw new ArgumentException("Title must be less than 100 characters");

        if (string.IsNullOrWhiteSpace(createTodo.Description))
            throw new ArgumentException("Description is required");

        var todo = new TodoItem
        {
            Title = createTodo.Title,
            Description = createTodo.Description,
            CreatedAt = createTodo.CreatedAt,
            IsCompleted = false
        };

        _context.Todo_Items.Add(todo);
        await _context.SaveChangesAsync();

        return new TodoDTO
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            CreatedAt = todo.CreatedAt,
            IsCompleted = todo.IsCompleted
        };
    }
    public async Task<TodoDTO> UpdateAsync(int id, UpdateTodoItemDTO updateTodo)
    {
        var todo = await _context.Todo_Items.FindAsync(id);

        if (todo == null)
            return null;

        if (string.IsNullOrWhiteSpace(updateTodo.Title))
            throw new ArgumentException("Title is required");

        todo.Title = updateTodo.Title;
        todo.Description = updateTodo.Description;
        todo.IsCompleted = updateTodo.IsCompleted;

        await _context.SaveChangesAsync();

        return new TodoDTO
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            CreatedAt = todo.CreatedAt,
            IsCompleted = todo.IsCompleted
        };
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var todo = _context.Todo_Items.Find(id);

        if (todo == null)
            return false;

        _context.Todo_Items.Remove(todo);

        await _context.SaveChangesAsync();

        return true;
    }
}
