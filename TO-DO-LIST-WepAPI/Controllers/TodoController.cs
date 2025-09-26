using Microsoft.AspNetCore.Mvc;
using TO_DO_LIST_WepAPI.Models.DTOs;
using TO_DO_LIST_WepAPI.Models.TaskItemDTO;
using TO_DO_LIST_WepAPI.Services;

namespace TO_DO_LIST_WepAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoDTO>>> GetAll()
    {
        var todos = await _todoService.GetAllAsync();
        return Ok(todos);
    }

    [HttpGet("{id}")] 
    public async Task<ActionResult<TodoDTO>> GetById(int id) 
    {
        var todo = await _todoService.GetByIdAsync(id);

        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    public async Task<ActionResult<TodoDTO>> Create(CreateTodoItemDTO create) 
    {
        try
        {
            var todo = await _todoService.CreateAsync(create);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")] 
    public async Task<ActionResult<TodoDTO>> Update(int id, UpdateTodoItemDTO update) 
    {
        try
        {
            var todo = await _todoService.UpdateAsync(id, update); 

            if (todo == null)
                return NotFound();

            return Ok(todo);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _todoService.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}