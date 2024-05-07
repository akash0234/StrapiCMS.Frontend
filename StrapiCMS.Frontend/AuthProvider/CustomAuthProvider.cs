using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using StrapiCMS.Entity.AuthResponseModel.AuthResponseModel;
using StrapiCMS.Entity.Enums;
using StrapiCMS.Frontend.Components.Layout;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace StrapiCMS.Frontend.AuthProvider
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
      
        private readonly ProtectedLocalStorage _protectedLocalStorage;


        
        public CustomAuthProvider(ProtectedLocalStorage ProtectedLocalStorage)
        {
           
            _protectedLocalStorage = ProtectedLocalStorage;
          
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await _protectedLocalStorage.GetAsync<AuthResponseModel>(LocalStorageKeys.UserAuth.ToString());

            if (string.IsNullOrWhiteSpace(savedToken.Value?.jwt))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var jwtClaims = ParseClaimsFromJwt(savedToken.Value?.jwt);

            // Check if the token has expired
            // Check if the token has expired
            var expirationClaim = jwtClaims.FirstOrDefault(claim => claim.Type == "exp");
            if (expirationClaim != null && long.TryParse(expirationClaim.Value, out var expirationTime))
            {
                var expirationDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(expirationTime);
                if (expirationDateTimeOffset <= DateTimeOffset.UtcNow)
                {
                    // Token has expired, log out the user
                    await _protectedLocalStorage.DeleteAsync(LocalStorageKeys.UserAuth.ToString());
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
            }
            else
            {
                // No expiration claim found or invalid expiration format, consider it expired
                await _protectedLocalStorage.DeleteAsync(LocalStorageKeys.UserAuth.ToString());
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var identityClaims = new List<Claim>(jwtClaims)
            {
                // Add more claims as needed
                new Claim(ClaimTypes.Role, "Customer"),
                new Claim(ClaimTypes.Name, savedToken.Value.user.email),
                new Claim("IsBlocked", savedToken.Value.user.blocked.ToString()),
                new Claim("createdAt", savedToken.Value.user.createdAt.ToString()),
            };

            var identity = new ClaimsIdentity(identityClaims, "jwt");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }




        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
