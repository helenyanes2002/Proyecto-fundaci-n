using Fundacion.API.Helpers;
using Fundacion.Shared.Entidades;
using Fundacion.Shared.Enums;
using System.Diagnostics.Eventing.Reader;

namespace Fundacion.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVolunterAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "OAP", "Admin", "maryorimontoya1113908@gmail.com", "305232456", "Cr 45 7896", UserType.Admin);

        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }


        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {

                user = new User
                {
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    UserName = email,
                    Address = address,
                    UserType = userType,
                };

                await _userHelper.AdduserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }   
            return user;
        }

        private async Task CheckVolunterAsync()
        {
            if (!_context.Voluntarios.Any())
            {
                _context.Voluntarios.Add(new Voluntario { Nombre = "Juan",Direccion = "Anaa",Correo = "Pedro", Telefono = "2937937", Disponibilidad = "2 hooras", Area = "n" });
                _context.Voluntarios.Add(new Voluntario { Nombre = "Luisa", Direccion = "Bello", Correo = "n", Telefono = "i2y382", Disponibilidad = "2 hooras", Area = "n" });
                _context.Voluntarios.Add(new Voluntario { Nombre = "Marisol", Direccion = "Paris", Correo = "Pendro", Telefono = "2y38", Disponibilidad = "2 hooras", Area = "n" });
                _context.Voluntarios.Add(new Voluntario { Nombre = "Ximena", Direccion = "Guatemala", Correo = "Pekxkdro", Telefono = "293u793", Disponibilidad = "2 hooras", Area = "n" });

            }

            await _context.SaveChangesAsync();

        }
    }
}
