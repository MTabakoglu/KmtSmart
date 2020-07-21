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
    public class LiveDataService : ILiveDataService
    {
        HttpClient _httpClient;
        public LiveDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(LiveDataModel liveDataModel)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath("livedata", "add"), liveDataModel);
        }

        public async Task Delete(LiveDataModel liveDataModel)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath("livedata", "delete"), liveDataModel);
        }

        public async Task<LiveDataModel> GetData(int LiveDataId)
        {
            return await _httpClient.GetJsonAsync<LiveDataModel>(PathHelper.GetApiServerPath("livedata", "getbyid","Id",LiveDataId));
        }

        public async Task<ListLiveDataModel[]> GetDeviceData(int DeviceId)
        {
            return await _httpClient.GetJsonAsync<ListLiveDataModel[]>(PathHelper.GetApiServerPath("livedata", "getdevicedata", "deviceId", DeviceId));
        }

        public async Task<LiveDataModel> GetLastData()
        {
            return await _httpClient.GetJsonAsync<LiveDataModel>(PathHelper.GetApiServerPath("livedata", "getlastdata"));
        }
        public async Task<LiveDataModel> GetLastData(int DeviceId)
        {
            string path = PathHelper.GetApiServerPath("livedata", "getlastDevicedata", "deviceId", DeviceId);
            return await _httpClient.GetJsonAsync<LiveDataModel>(path);
        }

        public async Task<LiveDataModel[]> GetList()
        {
            return await _httpClient.GetJsonAsync<LiveDataModel[]>(PathHelper.GetApiServerPath("livedata", "getall"));
        }

        public async Task Update(LiveDataModel liveDataModel)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath("livedata", "update"), liveDataModel);
        }
    }
}
