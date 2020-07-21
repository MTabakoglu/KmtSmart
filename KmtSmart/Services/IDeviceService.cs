using KmtSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    public interface IDeviceService
    {
        Task<DeviceModel[]> GetAllDevices();
        Task<DeviceModel[]> GetDevicesByUser(int UserId);
        Task<DeviceModel[]> GetDevicesByType(int TypeId);
        Task<DeviceModel> GetDeviceById(int DeviceId);
        Task Add(DeviceModel deviceModel);
        Task Update(DeviceModel deviceModel);
        Task Delete(DeviceModel deviceModel);
    }
}
