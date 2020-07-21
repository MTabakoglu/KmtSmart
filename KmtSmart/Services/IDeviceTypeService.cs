using KmtSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    public interface IDeviceTypeService
    {
        Task<DeviceTypeModel[]> GetAllDevices();
        Task<DeviceTypeModel> GetDeviceTypeById(int DeviceTypeId);
        Task Add(DeviceTypeModel deviceTypeModel);
        Task Update(DeviceTypeModel deviceTypeModel);
        Task Delete(DeviceTypeModel deviceTypeModel);
    }
}
