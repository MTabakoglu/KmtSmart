using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using KmtSmart.Services;
using KmtSmart.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace KmtSmart
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddSingleton<BlazorTimer>();

            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IDeviceService, DeviceService>();
            builder.Services.AddSingleton<ILiveDataService, LiveDataService>();
            builder.Services.AddSingleton<IDeviceTypeService, DeviceTypeService>();
            builder.Services.AddSingleton<IWorkOrderService, WorkOrderService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustumAuthenticationStateProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddLocalization();

            await builder.Build().RunAsync();
        }

    }
}
