using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Fundacion.WEB.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var oapUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Orlando"),
                new Claim("LastName", "A"),
                new Claim(ClaimTypes.Name, "orlapez@gmail.com"),
            },
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }
}
