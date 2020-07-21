using KmtSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    public interface IWorkOrderService
    {
        Task<WorkOrderModel[]> GetList();
        Task<WorkOrderModel[]> GetDeviceData(int DeviceId);
        Task<WorkOrderModel> GetById(int workOrderId);
        Task Add(WorkOrderModel workOrder);
        Task Update(WorkOrderModel workOrder);
        Task Delete(WorkOrderModel workOrder);

    }
}
