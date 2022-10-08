using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Entities;

namespace TodoWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase
{
    private readonly ILogger<TodoItemController> _logger;
    private readonly ApplicationDbContext _context;

    public TodoItemController(ILogger<TodoItemController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetTodoItems")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
    {
        var full = await _context.TodoItems.ToListAsync();
        return Ok(full);
    }

    [HttpPost(Name = "AddTodoItems")]
    public async Task<ActionResult> Add(string title)
    {
        var todoItem = new TodoItem(title);
        await _context.TodoItems.AddAsync(todoItem);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("{title}")]
    public async Task<ActionResult<TodoItem>> GetTodoItem(string title)
    {
        var todoItem = await _context.TodoItems.FirstOrDefaultAsync(x => x.Title == title);
        if (todoItem == null)
        {
            return NotFound();
        }

        return Ok(todoItem);
    }

}
