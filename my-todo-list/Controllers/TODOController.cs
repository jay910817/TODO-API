using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_todo_list.Data;
using my_todo_list.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_todo_list.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TODOController : ControllerBase
    {
        private readonly todoDBContext _context;
        public TODOController(todoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTODOList()
        {
            var result = _context.Todos.ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTODO(Todo newTODO)
        {
            await _context.Todos.AddAsync(newTODO);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTODO(int id)
        {
            var todo = _context.Todos.Where(t => t.Id == id).FirstOrDefault();
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }

}
