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
    [Route("/api/gastos")]
    public class GastosController : ControllerBase
    {
        private readonly DataContext _context;

        public GastosController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]

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
            var gasto = await _context.Gastos.FirstOrDefaultAsync(x => x.Id == id);

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

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.Gastos.ToListAsync());
        }

        [AllowAnonymous]
        [HttpGet("combo/{GastoId:int}")]
        public async Task<ActionResult> GetCombo(int GastoId)
        {
            return Ok(await _context.Gastos
                .Where(x => x.Id == GastoId)
                .ToListAsync());
        }

    }
}



