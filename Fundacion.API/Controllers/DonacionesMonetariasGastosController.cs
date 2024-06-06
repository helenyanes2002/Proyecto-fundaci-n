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
    [Route("/api/donacionesMonetariasGastos")]
    public class DonacionesMonetariasGastosController : ControllerBase
    {
        private readonly DataContext _context;

        public DonacionesMonetariasGastosController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]

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
            var donacionMonetariaGasto = await _context.DonacionesMonetariasGastos.FirstOrDefaultAsync(x => x.Id == id);

            if (donacionMonetariaGasto == null)
            {
                return NotFound();
            }
            return Ok(donacionMonetariaGasto);
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

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.DonacionesMonetariasGastos.ToListAsync());
        }

        [AllowAnonymous]
        [HttpGet("combo/{DonacionesMonetariaId:int}")]
        public async Task<ActionResult> GetCombo(int DonacionesMonetariaId)
        {
            return Ok(await _context.DonacionesMonetariasGastos
                .Where(x => x.Id == DonacionesMonetariaId)
                .ToListAsync());
        }










    }
}


