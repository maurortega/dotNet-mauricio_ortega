using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaEmpleadosController : ControllerBase
    {
        private readonly RealDBContext _context;

        public MaEmpleadosController(RealDBContext context)
        {
            _context = context;
        }

        // GET: api/MaEmpleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaEmpleado>>> GetMaEmpleados()
        {
            return await _context.MaEmpleados.ToListAsync();
        }

        // GET: api/MaEmpleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaEmpleado>> GetMaEmpleado(int id)
        {
            var maEmpleado = await _context.MaEmpleados.FindAsync(id);

            if (maEmpleado == null)
            {
                return NotFound();
            }

            return maEmpleado;
        }

        // GET: api/MaEmpleados/ByIdentDocument/91489835
        [HttpGet("ByIdentDocument/{docIdentNumero}")]
        public async Task<ActionResult<IEnumerable<MaEmpleado>>> GetMaEmpleadosByIdentDocument(int docIdentNumero)
        {
            var list = await _context.MaEmpleados.FromSqlRaw<MaEmpleado>($"exec GetMaEmpleadosByIdentDocument @docIdentNumero={docIdentNumero.ToString()}").ToListAsync();
            return new ActionResult<IEnumerable<MaEmpleado>>(list);
        }


        // GET: api/MaEmpleados/ByName/palabras
        [HttpGet("ByName/{palabras}")]
        public async Task<ActionResult<IEnumerable<MaEmpleado>>> GetMaEmpleadosByName(string palabras)
        {
            var list = await _context.MaEmpleados.FromSqlRaw<MaEmpleado>($"exec GetMaEmpleadosByName @palabras='{palabras}'").ToListAsync();
            //var prmList = new List<System.Data.Common.DbCommand>();
            //prmList.Add(new System.Data.Common.DbParameter(){ ParameterName = "" });

            return new ActionResult<IEnumerable<MaEmpleado>>(list);
        }

        // PUT: api/MaEmpleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaEmpleado(int id, MaEmpleado maEmpleado)
        {
            if (id != maEmpleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(maEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaEmpleadoExists(id))
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

        // POST: api/MaEmpleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaEmpleado>> PostMaEmpleado(MaEmpleado maEmpleado)
        {
            _context.MaEmpleados.Add(maEmpleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaEmpleado", new { id = maEmpleado.Id }, maEmpleado);
        }

        // DELETE: api/MaEmpleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaEmpleado(int id)
        {
            var maEmpleado = await _context.MaEmpleados.FindAsync(id);
            if (maEmpleado == null)
            {
                return NotFound();
            }

            _context.MaEmpleados.Remove(maEmpleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaEmpleadoExists(int id)
        {
            return _context.MaEmpleados.Any(e => e.Id == id);
        }
    }
}
