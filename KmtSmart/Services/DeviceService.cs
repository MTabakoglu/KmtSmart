using KmtSmart.Models;
using KmtSmart.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    public class DeviceService : IDeviceService
    {
        HttpClient _httpClient;
        public DeviceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Add(DeviceModel deviceModel)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath("device", "add"), deviceModel);
        }

        public async Task Delete(DeviceModel deviceModel)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath("device", "delete"), deviceModel);
        }

        public async Task<DeviceModel> GetDeviceById(int DeviceId)
        {
            return await _httpClient.GetJsonAsync<DeviceModel>(PathHelper.GetApiServerPath("device", "getbyid", "Id", DeviceId));
        }

        public async Task<DeviceModel[]> GetAllDevices()
        {
            return await _httpClient.GetJsonAsync<DeviceModel[]>(PathHelper.GetApiServerPath("device", "getall"));
        }

        public async Task<DeviceModel[]> GetDevicesByType(int TypeId)
        {
            return await _httpClient.GetJsonAsync<DeviceModel[]>(PathHelper.GetApiServerPath("device", "getdevicebytype", "TypeId", TypeId));
        }

        public async Task<DeviceModel[]> GetDevicesByUser(int UserId)
        {
            return await _httpClient.GetJsonAsync<DeviceModel[]>(PathHelper.GetApiServerPath("device", "getuserdevices", "userid", UserId));
        }

        public async Task Update(DeviceModel deviceModel)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath("device", "update"), deviceModel);
        }
    }
}
