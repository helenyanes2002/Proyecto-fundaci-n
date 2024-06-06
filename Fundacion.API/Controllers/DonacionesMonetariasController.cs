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
    [Route("/api/donacionesMonetarias")]
    public class DonacionesMonetariasController : ControllerBase
    {
        private readonly DataContext _context;

        public DonacionesMonetariasController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]

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
            var donacionmonetaria = await _context.DonacionesMonetarias.FirstOrDefaultAsync(x => x.Id == id);
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

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.DonacionesMonetarias.ToListAsync());
        }

        [AllowAnonymous]
        [HttpGet("combo/{DonacionMonetariaId:int}")]
        public async Task<ActionResult> GetCombo(int DonacionMonetariaId)
        {
            return Ok(await _context.DonacionesMonetarias
                .Where(x => x.Id == DonacionMonetariaId)
                .ToListAsync());
        }
    }
}



