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
            await CheckPetTypesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1103465438", "Helen", "Yanes", "orlapez@gmail.com", "305232456", "Cr 45 7896", UserType.Admin);

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

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);



            }
            return user;
        }

        private async Task CheckPetTypesAsync()
        {
            if (!_context.Voluntarios.Any())
            {
                _context.Voluntarios.Add(new Voluntario { Nombre = "Juan" });
                _context.Voluntarios.Add(new Voluntario { Nombre = "Anaa" });
                _context.Voluntarios.Add(new Voluntario { Nombre = "Pedro" });
                _context.Voluntarios.Add(new Voluntario { Nombre = "Luisa" });

            }

            await _context.SaveChangesAsync();

        }
    }
}
