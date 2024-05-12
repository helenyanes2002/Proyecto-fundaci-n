using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Route("/api/programasbeneficiarios")]
    public class ProgramasBeneficiariosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgramasBeneficiariosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ProgramasBeneficiarios.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProgramaBeneficiario programabeneficiario)
        {
            _context.Add(programabeneficiario);
            await _context.SaveChangesAsync();
            return Ok(programabeneficiario);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var beneficiario = await
            _context.ProgramasBeneficiarios.SingleOrDefaultAsync(x => x.Id == id);

            if (beneficiario == null)
            {
                return NotFound();
            }
            return Ok(beneficiario);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(ProgramaBeneficiario programabeneficiario)
        {
            _context.Update(programabeneficiario);
            await _context.SaveChangesAsync();
            return Ok(programabeneficiario);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.ProgramasBeneficiarios

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




