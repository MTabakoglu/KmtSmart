using KmtSmart.Models;
using KmtSmart.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KmtSmart.Services
{
    public class WorkOrderService : IWorkOrderService
    {
        HttpClient _httpClient;
        private string controller = "workorder";
        public WorkOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Add(WorkOrderModel workOrder)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath(controller, "add"), workOrder);
        }

        public async Task Delete(WorkOrderModel workOrder)
        {
            try
            {
                //await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath(controller, "delete"), workOrder);
                await _httpClient.SendJsonAsync(HttpMethod.Post, PathHelper.GetApiServerPath(controller, "delete"),
                    workOrder);

            }
            catch (Exception e)
            {
                string dosya_yolu = @"C:\KmtSmartException.txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(e.Message);
                sw.WriteLine(e.InnerException.Message);
                sw.WriteLine(e.Source);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            //await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath(controller, "delete"), workOrder);
        }

        public async Task<WorkOrderModel[]> GetDeviceData(int DeviceId)
        {
            return await _httpClient.GetJsonAsync<WorkOrderModel[]>(PathHelper.GetApiServerPath(controller, "getdevicedata","deviceid",DeviceId));
        }
        public async Task<WorkOrderModel> GetById(int workOrderId)
        {
            return await _httpClient.GetJsonAsync<WorkOrderModel>(PathHelper.GetApiServerPath(controller, "getbyid", "id", workOrderId));
        }
        public async Task<WorkOrderModel[]> GetList()
        {
            return await _httpClient.GetJsonAsync<WorkOrderModel[]>(PathHelper.GetApiServerPath(controller, "getall"));
        }

        public async Task Update(WorkOrderModel workOrder)
        {
            await _httpClient.PostJsonAsync(PathHelper.GetApiServerPath(controller, "update"), workOrder);
        }
    }
}
