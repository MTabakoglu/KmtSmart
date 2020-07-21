using KmtSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    public interface ILiveDataService
    {
        Task<LiveDataModel[]> GetList();
        Task<ListLiveDataModel[]> GetDeviceData(int DeviceId);
        Task<LiveDataModel> GetData(int LiveDataId);
        Task<LiveDataModel> GetLastData();
        Task<LiveDataModel> GetLastData(int DeviceId);
        Task Add(LiveDataModel liveDataModel);
        Task Update(LiveDataModel liveDataModel);
        Task Delete(LiveDataModel liveDataModel);
    }
}
