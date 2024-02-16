using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.API;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public TodoListController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> ItemsWithoutCompletedDate()
        {
            var todoItems = await _dbContext.ToDoItems
                .Where(item => item.CompletedDate == null)
                .ToListAsync();

            return Ok(todoItems);
        }
        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateItem([FromBody] TodoItem newToDoItem)
        {
            if (newToDoItem == null)
            {
                return BadRequest("Invalid payload");
            }

            _dbContext.ToDoItems.Add(newToDoItem);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemByID), new { id = newToDoItem.Id }, newToDoItem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetItemByID(int id)
        {
            var todoItem = await _dbContext.ToDoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost("{id}/complete")]
        public async Task<ActionResult> MarkItemComplete(int id)
        {
            var todoItem = await _dbContext.ToDoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.CompletedDate = DateTime.UtcNow;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Handle exceptions appropriately
                return StatusCode(500, "An error occurred while saving the data.");
            }

            return NoContent(); // 204 No Content
        }
    }
}
