using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Fundacion.WEB.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Orlando"),
                new Claim("LastName", "A"),
                new Claim(ClaimTypes.Name, "orlapez@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }
}
