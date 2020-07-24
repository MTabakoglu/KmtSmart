using Blazored.LocalStorage;
using KmtSmart.Models;
using KmtSmart.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    public class AuthService : IAuthService
    {
        HttpClient _httpClient;
        ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public bool IsLoggedIn { get; set; }
        public AuthService(HttpClient httpClient,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage=localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostJsonAsync<TokenModel>(PathHelper.GetApiServerPath("Auth","login"),loginModel);

            if (!string.IsNullOrEmpty(response.Token))
            {
                await _localStorage.SetItemAsync<string>("token", response.Token);
                await _localStorage.SetItemAsync<DateTime>("expiry", response.Expiration);
                await _localStorage.SetItemAsync<int>("UserId", response.Identity);
                IsLoggedIn = true;
                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);
                //((CustumAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
                return await Task.FromResult(true);
            }
            else return await Task.FromResult(false);
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            await _localStorage.RemoveItemAsync("expiry");
            await _localStorage.RemoveItemAsync("UserId");
            IsLoggedIn = false;
            ((CustumAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }



        public async Task<bool> Register(RegisterModel registerModel)
        {
            var response = await _httpClient.PostJsonAsync<TokenModel>(PathHelper.GetApiServerPath("Auth", "register"), registerModel);
            if (!string.IsNullOrEmpty(response.Token))
            {
                await _localStorage.SetItemAsync<string>("token", response.Token);
                IsLoggedIn = true;
                return true;
            }
            return false;
        }

        public int GetUserId(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = jwtSecurityTokenHandler.ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwt.Claims, "custom");
            return int.Parse(identity.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}