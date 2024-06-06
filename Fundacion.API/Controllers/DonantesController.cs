using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/donantes")]
    public class DonantesController : ControllerBase
    {
        private readonly DataContext _context;

        public DonantesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Donantes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Donante donante)
        {
            _context.Add(donante);
            await _context.SaveChangesAsync();
            return Ok(donante);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var donante = await
            _context.Donantes.SingleOrDefaultAsync(x => x.Id == id);

            if (donante == null)
            {
                return NotFound();
            }
            return Ok(donante);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Donante donante)
        {
            _context.Update(donante);
            await _context.SaveChangesAsync();
            return Ok(donante);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Donantes

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



