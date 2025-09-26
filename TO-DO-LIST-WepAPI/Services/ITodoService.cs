using TO_DO_LIST_WepAPI.Models.DTOs;
using TO_DO_LIST_WepAPI.Models.TaskItemDTO;

namespace TO_DO_LIST_WepAPI.Services;

public interface ITodoService
{
    Task<List<TodoDTO>> GetAllAsync();
    Task<TodoDTO> GetByIdAsync(int id);
    Task<TodoDTO> CreateAsync(CreateTodoItemDTO createTodo);
    Task<TodoDTO> UpdateAsync(int id, UpdateTodoItemDTO updateTodo);
    Task<bool> DeleteAsync(int id);
}
