using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Blazored.LocalStorage;

namespace KmtSmart.Utilities
{
    public class CustumAuthenticationStateProvider : AuthenticationStateProvider
    {
       
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public CustumAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await _localStorage.GetItemAsync<string>("token");

            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            }

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = jwtSecurityTokenHandler.ReadJwtToken(savedToken);       
            var identity = new ClaimsIdentity(jwt.Claims, "custom");
            ClaimsPrincipal user;

            var expiry = await _localStorage.GetItemAsync<DateTime>("expiry");
            if (expiry != null)
            {
                if (expiry > DateTime.Now)
                {
                    user = new ClaimsPrincipal(identity);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
                }
                else
                {
                    user = new ClaimsPrincipal(new ClaimsIdentity());
                    await _localStorage.RemoveItemAsync("token");
                    _httpClient.DefaultRequestHeaders.Authorization = null;
                }
                
            }else user = new ClaimsPrincipal(new ClaimsIdentity());

            return await Task.FromResult(new AuthenticationState(user));
        }
      


        public void MarkUserAsAuthenticated(string email)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
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
