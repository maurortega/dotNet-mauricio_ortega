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
    public class TbTipoDocumentoIdentsController : ControllerBase
    {
        private readonly RealDBContext _context;

        public TbTipoDocumentoIdentsController(RealDBContext context)
        {
            _context = context;
        }

        // GET: api/TbTipoDocumentoIdents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTipoDocumentoIdent>>> GetTbTipoDocumentoIdents()
        {
            return await _context.TbTipoDocumentoIdents.ToListAsync();
        }

        // GET: api/TbTipoDocumentoIdents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTipoDocumentoIdent>> GetTbTipoDocumentoIdent(string id)
        {
            var tbTipoDocumentoIdent = await _context.TbTipoDocumentoIdents.FindAsync(id);

            if (tbTipoDocumentoIdent == null)
            {
                return NotFound();
            }

            return tbTipoDocumentoIdent;
        }

        // PUT: api/TbTipoDocumentoIdents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTipoDocumentoIdent(string id, TbTipoDocumentoIdent tbTipoDocumentoIdent)
        {
            if (id != tbTipoDocumentoIdent.Simbolo)
            {
                return BadRequest();
            }

            _context.Entry(tbTipoDocumentoIdent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTipoDocumentoIdentExists(id))
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

        // POST: api/TbTipoDocumentoIdents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbTipoDocumentoIdent>> PostTbTipoDocumentoIdent(TbTipoDocumentoIdent tbTipoDocumentoIdent)
        {
            _context.TbTipoDocumentoIdents.Add(tbTipoDocumentoIdent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbTipoDocumentoIdentExists(tbTipoDocumentoIdent.Simbolo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbTipoDocumentoIdent", new { id = tbTipoDocumentoIdent.Simbolo }, tbTipoDocumentoIdent);
        }

        // DELETE: api/TbTipoDocumentoIdents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbTipoDocumentoIdent(string id)
        {
            var tbTipoDocumentoIdent = await _context.TbTipoDocumentoIdents.FindAsync(id);
            if (tbTipoDocumentoIdent == null)
            {
                return NotFound();
            }

            _context.TbTipoDocumentoIdents.Remove(tbTipoDocumentoIdent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbTipoDocumentoIdentExists(string id)
        {
            return _context.TbTipoDocumentoIdents.Any(e => e.Simbolo == id);
        }
    }
}
