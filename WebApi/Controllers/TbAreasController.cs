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
    public class TbAreasController : ControllerBase
    {
        private readonly RealDBContext _context;

        public TbAreasController(RealDBContext context)
        {
            _context = context;
        }

        // GET: api/TbAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbArea>>> GetTbAreas()
        {
            return await _context.TbAreas.ToListAsync();
        }

        // GET: api/TbAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbArea>> GetTbArea(int id)
        {
            var tbArea = await _context.TbAreas.FindAsync(id);

            if (tbArea == null)
            {
                return NotFound();
            }

            return tbArea;
        }

        // PUT: api/TbAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbArea(int id, TbArea tbArea)
        {
            if (id != tbArea.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAreaExists(id))
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

        // POST: api/TbAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbArea>> PostTbArea(TbArea tbArea)
        {
            _context.TbAreas.Add(tbArea);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbAreaExists(tbArea.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbArea", new { id = tbArea.Id }, tbArea);
        }

        // DELETE: api/TbAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbArea(int id)
        {
            var tbArea = await _context.TbAreas.FindAsync(id);
            if (tbArea == null)
            {
                return NotFound();
            }

            _context.TbAreas.Remove(tbArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbAreaExists(int id)
        {
            return _context.TbAreas.Any(e => e.Id == id);
        }
    }
}
