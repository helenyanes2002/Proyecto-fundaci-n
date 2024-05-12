using Fundacion.Shared.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Fundacion.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) {      
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




    }
}
