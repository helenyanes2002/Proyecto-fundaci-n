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
    [Route("/api/eventosVoluntarios")]
    public class EventosVoluntariosController : ControllerBase
    {
        private readonly DataContext _context;

        public EventosVoluntariosController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.EventosVoluntarios.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(EventoVoluntario eventovoluntario)
        {
            _context.Add(eventovoluntario);
            await _context.SaveChangesAsync();
            return Ok(eventovoluntario);
        }

        //Método Get- por Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var eventoVoluntario = await _context.EventosVoluntarios.FirstOrDefaultAsync(x => x.Id == id);
            if (eventoVoluntario == null)
            {
                return NotFound();
            }
            return Ok(eventoVoluntario);
        }

        //Método de actualizar
        [HttpPut]
        public async Task<ActionResult> Put(EventoVoluntario eventovoluntario)
        {
            _context.Update(eventovoluntario);
            await _context.SaveChangesAsync();
            return Ok(eventovoluntario);
        }

        //Método de borrar
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilasAfectadas = await _context.EventosVoluntarios

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
            return Ok(await _context.EventosVoluntarios.ToListAsync());
        }

        [AllowAnonymous]
        [HttpGet("combo/{EventoVoluntarioId:int}")]
        public async Task<ActionResult> GetCombo(int EventoVoluntarioId)
        {
            return Ok(await _context.EventosVoluntarios
                .Where(x => x.Id == EventoVoluntarioId)
                .ToListAsync());
        }
    }
}


