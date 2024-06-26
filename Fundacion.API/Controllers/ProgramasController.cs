﻿using Fundacion.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fundacion.Shared.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;


namespace Fundacion.API.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("/api/programas")]
    public class ProgramasController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgramasController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]

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
            var programa = await _context.Programas.FirstOrDefaultAsync(x => x.Id == id);

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

        [AllowAnonymous]
        [HttpGet("combo")]
        public async Task<ActionResult> GetCombo()
        {
            return Ok(await _context.Programas.ToListAsync());
        }

        [AllowAnonymous]
        [HttpGet("combo/{ProgramaId:int}")]
        public async Task<ActionResult> GetCombo(int ProgramaId)
        {
            return Ok(await _context.Programas
                .Where(x => x.Id == ProgramaId)
                .ToListAsync());
        }
    }
}


