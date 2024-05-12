using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Route("/api/gastos")]
    public class GastosController : ControllerBase
    {
        private readonly DataContext _context;

        public GastosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Gastos.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Gasto gasto)
        {
            _context.Add(gasto);
            await _context.SaveChangesAsync();
            return Ok(gasto);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var gasto = await
            _context.Gastos.SingleOrDefaultAsync(x => x.Id == id);

            if (gasto == null)
            {
                return NotFound();
            }
            return Ok(gasto);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Gasto gasto)
        {
            _context.Update(gasto);
            await _context.SaveChangesAsync();
            return Ok(gasto);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Gastos

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}



