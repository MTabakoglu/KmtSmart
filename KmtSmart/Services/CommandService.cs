using KmtSmart.Models;
using KmtSmart.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    public class CommandService : ICommandService
    {
        HttpClient _httpClient;
        public CommandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Add(CommandModel command)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath("command", "add"), command);
        }
    }
}
