using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Route("/api/donacionesMonetarias")]
    public class DonacionesMonetariasController : ControllerBase
    {
        private readonly DataContext _context;

        public DonacionesMonetariasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.DonacionesMonetarias.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(DonacionMonetaria donacionmonetaria)
        {
            _context.Add(donacionmonetaria);
            await _context.SaveChangesAsync();
            return Ok(donacionmonetaria);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var donacionmonetaria = await
            _context.DonacionesMonetarias.SingleOrDefaultAsync(x => x.Id == id);

            if (donacionmonetaria == null)
            {
                return NotFound();
            }
            return Ok(donacionmonetaria);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(DonacionMonetaria donacionmonetaria)
        {
            _context.Update(donacionmonetaria);
            await _context.SaveChangesAsync();
            return Ok(donacionmonetaria);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.DonacionesMonetarias

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



