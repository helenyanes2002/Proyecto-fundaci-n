using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Route("/api/eventosvoluntarios")]
    public class EventosVoluntariosController : ControllerBase
    {
        private readonly DataContext _context;

        public EventosVoluntariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.EventosVoluntarios.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(EventoVoluntario eventovoluntario)
        {
            _context.Add(eventovoluntario);
            await _context.SaveChangesAsync();
            return Ok(eventovoluntario);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var beneficiario = await
            _context.EventosVoluntarios.SingleOrDefaultAsync(x => x.Id == id);

            if (beneficiario == null)
            {
                return NotFound();
            }
            return Ok(beneficiario);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(EventoVoluntario eventovoluntario)
        {
            _context.Update(eventovoluntario);
            await _context.SaveChangesAsync();
            return Ok(eventovoluntario);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.EventosVoluntarios

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


