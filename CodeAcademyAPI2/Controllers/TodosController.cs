using CodeAcademyAPI2.Database;
using CodeAcademyAPI2.DTOs;
using CodeAcademyAPI2.Models;
using CodeAcademyAPI2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAcademyAPI2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController(IFakeTodoDatabase data, ITodoMapper mapper) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllTodos()
    {
        var todos = data.GetTodoItems();
        var dtos = mapper.Map(todos);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public IActionResult GetTodoById(int id)
    {
        var todo = data.GetTodoItem(id);
        if (todo == null)
        {
            return NotFound();
        }
        var dto = mapper.Map(todo);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult AddTodo([FromBody] TodoItemRequest itemDto) 
    {
        var todo = mapper.Map(itemDto);
        data.AddTodoItem(todo);
        return NoContent();
    }

    [HttpPut]
    public IActionResult Put(int id, [FromBody] TodoItemRequest todoItemRequest) 
    {
        var todo = data.GetTodoItem(id);
        if (todo == null)
        {
            return NotFound();
        }

        mapper.Project(todo, todoItemRequest);
        data.UpdateTodoItem(todo);
        return NoContent();
    }
}
