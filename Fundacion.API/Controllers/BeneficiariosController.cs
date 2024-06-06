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
    [Route("/api/beneficiarios")]
    public class BeneficiariosController : ControllerBase
    {
        private readonly DataContext _context;

        public BeneficiariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Beneficiarios.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Beneficiario beneficiario)
        {
            _context.Add(beneficiario);
            await _context.SaveChangesAsync();
            return Ok(beneficiario);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var beneficiario = await
            _context.Beneficiarios.SingleOrDefaultAsync(x => x.Id == id);

            if (beneficiario == null)
            {
                return NotFound();
            }
            return Ok(beneficiario);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Beneficiario beneficiario)
        {
            _context.Update(beneficiario);
            await _context.SaveChangesAsync();
            return Ok(beneficiario);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Beneficiarios

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








