using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TO_DO_LIST_WepAPI.Models.DTOs;
using TO_DO_LIST_WepAPI.Models.TaskItemDTO;
using TO_DO_LIST_WepAPI.Services;

namespace TO_DO_LIST_WepAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    //Se no serviço eu tenho um método GetAllAsync, eu preciso de uma ação GetAllAsync no controller.
    //Portanto, será necessário injetar o serviço no controller via DI.

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

    [HttpGet("id")]
    public async Task<ActionResult<List<TodoDTO>>> GetById(int id)
    {
        var todo = await _todoService.GetByIdAsync(id);

        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    public async Task<ActionResult<List<TodoDTO>>> Create(CreateTodoItemDTO create)
    {
        try
        {
            var todo = await _todoService.CreateAsync(create);

            // CreatedAtAction -> Retorna o status code 201 (Created) e o local do novo recurso criado
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPut("id")]
    public async Task<ActionResult<List<TodoDTO>>> Put(int id, UpdateTodoItemDTO update)
    {
        try
        {
            var todos = await _todoService.UpdateAsync(id, update);

            if (todos == null)
                return NotFound();

            return Ok(todos);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpDelete("id")]
    public async Task<ActionResult<List<TodoDTO>>>Delete(int id)
    {
        var result = await _todoService.DeleteAsync(id);

        if(!result)
            return NotFound();

        return NoContent();
    }
}
