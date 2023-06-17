using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class DummyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public DummyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
        ) : base(options, logger, encoder, clock)
    {
    }

    protected bool CompareHash(string password, string salt, string hash)
    {
        // Lav en 256-bit hash af "password + salt" - og gør det 100.000 gange!
        // HMACSHA256 er navnet på hash-funktionen der anvendes herunder
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        Console.WriteLine($"Password {password} plus salt {salt} er hashed til {hashed}");


        return hashed == hash;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string salt = "Salttest";
        string hashCake = "riC5NT0WpWCVsy6JIZyPYY5EseB4oEvwKUR8L4I7VXY=";
        string hashAdmin = "4O3GHJRNmpkyVC2Ak8EmFVOBD78Wc6aGOUlFbKshc4E=";

        // Vi undersøge lige om anonym adgang er tilladt
        var endpoint = Context.GetEndpoint();

        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            // Hvis anonym adgang er tilladt, skal vi ikke lave authentication
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        // Vi fisker en header ud hvor key er "Authorization"
        var authHeader = Request.Headers["Authorization"].ToString();

        // Vi tjekker efterfølgende på om "Authorization" findes, og på om dens value starte med "Password".
        if (authHeader != null && authHeader.StartsWith("Password", StringComparison.OrdinalIgnoreCase))
        {
            var password = authHeader.Substring("Password ".Length).Trim();

            // Denne 2x if struktur burde forbedres til at gemme hashen og tjekke dem i if i stedet for at hashe for hver rolle
            if (CompareHash(password, salt, hashAdmin))
            {
                // Vi opretter et "claim"
                var claims = new[] { new Claim("Role", "Admin") };
                var identity = new ClaimsIdentity(claims);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Claim returneres og giver nu adgang til endpoints der i deres 
                // policty har "Role = Admin".
                return Task.FromResult(AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, "DummyAuthentication")));
            }

            // Tilføjer en ekstra ting til at autentificere det andet endpoint med password
            if (CompareHash(password, salt, hashCake))
            {
                // Vi opretter et "claim"
                var claims = new[] { new Claim("Role", "CakeLover") };
                var identity = new ClaimsIdentity(claims);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                return Task.FromResult(AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, "DummyAuthentication")));
            }
        }
 
        Response.StatusCode = 401;
        return Task.FromResult(AuthenticateResult.Fail("Invalid Password"));  
    }
}