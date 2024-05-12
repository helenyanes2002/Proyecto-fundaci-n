using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Route("/api/empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpleadosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Empleados.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Empleado empleado)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();
            return Ok(empleado);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var empleado = await
            _context.Empleados.SingleOrDefaultAsync(x => x.Id == id);

            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(Empleado empleado)
        {
            _context.Update(empleado);
            await _context.SaveChangesAsync();
            return Ok(empleado);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.Empleados

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


