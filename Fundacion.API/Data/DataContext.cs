using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Fundacion.Shared.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fundacion.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Donante> Donantes { get; set; }
        public DbSet<DonacionMaterial> DonacionesMateriales { get; set; }
        public DbSet<DonacionMonetaria> DonacionesMonetarias { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Programa> Programas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EventoVoluntario> EventosVoluntarios { get; set; }
        public DbSet<DonacionMonetariaGasto> DonacionesMonetariasGastos { get; set; }
        public DbSet<ProgramaBeneficiario> ProgramasBeneficiarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
