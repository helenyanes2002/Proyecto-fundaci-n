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
    [Route("/api/donacionesMateriales")]
    public class DonacionesMaterialesController : ControllerBase
    {
        private readonly DataContext _context;

        public DonacionesMaterialesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.DonacionesMateriales.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(DonacionMaterial donacionmaterial)
        {
            _context.Add(donacionmaterial);
            await _context.SaveChangesAsync();
            return Ok(donacionmaterial);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var donacionmaterial = await
            _context.DonacionesMateriales.SingleOrDefaultAsync(x => x.Id == id);

            if (donacionmaterial == null)
            {
                return NotFound();
            }
            return Ok(donacionmaterial);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(DonacionMaterial donacionmaterial)
        {
            _context.Update(donacionmaterial);
            await _context.SaveChangesAsync();
            return Ok(donacionmaterial);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.DonacionesMateriales

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



