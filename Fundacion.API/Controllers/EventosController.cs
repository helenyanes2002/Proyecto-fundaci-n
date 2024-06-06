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
    [Route("/api/eventos")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _context;

        public EventosController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Eventos.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento evento)
        {
            _context.Add(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);

            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Evento evento)
        {
            _context.Update(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Eventos

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.Eventos.ToListAsync());
        }

        [AllowAnonymous]
        [HttpGet("combo/{EventoId:int}")]
        public async Task<ActionResult> GetCombo(int EventoId)
        {
            return Ok(await _context.Eventos
                .Where(x => x.Id == EventoId)
                .ToListAsync());
        }

    }
}



