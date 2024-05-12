using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Route("/api/programas")]
    public class ProgramasController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgramasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Programas.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Programa programa)
        {
            _context.Add(programa);
            await _context.SaveChangesAsync();
            return Ok(programa);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var programa = await
            _context.Programas.SingleOrDefaultAsync(x => x.Id == id);

            if (programa == null)
            {
                return NotFound();
            }
            return Ok(programa);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Programa programa)
        {
            _context.Update(programa);
            await _context.SaveChangesAsync();
            return Ok(programa);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Programas

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


