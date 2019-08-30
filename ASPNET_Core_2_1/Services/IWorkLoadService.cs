using System.Collections.Generic;
using ASPNET_Core_2_1.Models;

namespace ASPNET_Core_2_1.Services
{
    public interface IWorkLoadService
    {
        IJsonService JsonService { get; set; }
        IDemandService DemandService { get; set; }
        List<WorkLoad> GenerateWorkLoads();
        List<WorkLoad> GetWorkLoads();
        bool SaveWorkLoad();
    }
}