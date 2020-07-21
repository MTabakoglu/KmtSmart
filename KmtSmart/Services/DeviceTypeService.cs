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
    public class DeviceTypeService : IDeviceTypeService
    {

        HttpClient _httpClient;
        public DeviceTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task Add(DeviceTypeModel deviceTypeModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DeviceTypeModel deviceTypeModel)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceTypeModel[]> GetAllDevices()
        {
            throw new NotImplementedException();
        }

        public async Task<DeviceTypeModel> GetDeviceTypeById(int DeviceTypeId)
        {
            return await _httpClient.GetJsonAsync<DeviceTypeModel>(PathHelper.GetApiServerPath("devicetype", "getbyid", "id", DeviceTypeId));
        }

        public Task Update(DeviceTypeModel deviceTypeModel)
        {
            throw new NotImplementedException();
        }
    }
}
