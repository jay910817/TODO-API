using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_todo_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TODOController : ControllerBase
    {
    }
    public async Task<ActionResult<IEnumerable<Todo>>> GetTODOList()
    {
        var result = Context.Todo.ToList();
        return Ok(result);
    }
    public async Task<IActionResult>AddTODO(Todo newTODO)
    {
        await _context.Todo.AddAsync(newTODO);
        await _context.SaveChangesAsync();
        return Ok();
    }
    public async Task<ActionResult>DeleteTODO(int id)
    {
        var todo = _context.Todo.Where(t => t.Id == id).FirstOrDefault();
        if (todo != null)
        {
            _context.Todo.Remove(todo);
            await _context.SaveChangesAsync();
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }


}
