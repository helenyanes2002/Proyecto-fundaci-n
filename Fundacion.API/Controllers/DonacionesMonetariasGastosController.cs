using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Route("/api/donacionesMonetariasGastos")]
    public class DonacionesMonetariasGastosController : ControllerBase
    {
        private readonly DataContext _context;

        public DonacionesMonetariasGastosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.DonacionesMonetariasGastos.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(DonacionMonetariaGasto donacionmonetariagasto)
        {
            _context.Add(donacionmonetariagasto);
            await _context.SaveChangesAsync();
            return Ok(donacionmonetariagasto);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var beneficiario = await
            _context.DonacionesMonetariasGastos.SingleOrDefaultAsync(x => x.Id == id);

            if (beneficiario == null)
            {
                return NotFound();
            }
            return Ok(beneficiario);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(DonacionMonetariaGasto donacionmonetariagasto)
        {
            _context.Update(donacionmonetariagasto);
            await _context.SaveChangesAsync();
            return Ok(donacionmonetariagasto);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.DonacionesMonetariasGastos

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


