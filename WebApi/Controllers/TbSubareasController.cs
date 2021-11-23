using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbSubareasController : ControllerBase
    {
        private readonly RealDBContext _context;

        public TbSubareasController(RealDBContext context)
        {
            _context = context;
        }

        // GET: api/TbSubareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSubarea>>> GetTbSubareas()
        {
            return await _context.TbSubareas.ToListAsync();
        }

        // GET: api/TbSubareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSubarea>> GetTbSubarea(int id)
        {
            var tbSubarea = await _context.TbSubareas.FindAsync(id);

            if (tbSubarea == null)
            {
                return NotFound();
            }

            return tbSubarea;
        }

        // PUT: api/TbSubareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSubarea(int id, TbSubarea tbSubarea)
        {
            if (id != tbSubarea.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbSubarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSubareaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TbSubareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbSubarea>> PostTbSubarea(TbSubarea tbSubarea)
        {
            _context.TbSubareas.Add(tbSubarea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbSubareaExists(tbSubarea.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbSubarea", new { id = tbSubarea.Id }, tbSubarea);
        }

        // DELETE: api/TbSubareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbSubarea(int id)
        {
            var tbSubarea = await _context.TbSubareas.FindAsync(id);
            if (tbSubarea == null)
            {
                return NotFound();
            }

            _context.TbSubareas.Remove(tbSubarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbSubareaExists(int id)
        {
            return _context.TbSubareas.Any(e => e.Id == id);
        }
    }
}
