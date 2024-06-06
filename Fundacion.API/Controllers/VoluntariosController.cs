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
    [Route("/api/voluntarios")]
    public class VoluntariosController : ControllerBase
    {
        private readonly DataContext _context;

        public VoluntariosController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Voluntarios.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Voluntario voluntario)
        {
            _context.Add(voluntario);
            await _context.SaveChangesAsync();
            return Ok(voluntario);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var voluntario = await _context.Voluntarios.FirstOrDefaultAsync(x => x.Id == id);

            if (voluntario == null)
            {
                return NotFound();
            }
            return Ok(voluntario);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Voluntario voluntario)
        {
            _context.Update(voluntario);
            await _context.SaveChangesAsync();
            return Ok(voluntario);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Voluntarios

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
            return Ok(await _context.Voluntarios.ToListAsync());
        }

        [AllowAnonymous]
        [HttpGet("combo/{VoluntarioId:int}")]
        public async Task<ActionResult> GetCombo(int VoluntarioId)
        {
            return Ok(await _context.Voluntarios
                .Where(x => x.Id == VoluntarioId)
                .ToListAsync());
        }

    }
}

