using ASPNET_Core_2_1.Models;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Services
{
    public interface IDemandService
    {
        List<Demand> GetDemands();
        List<DemandDT> GetDemandsDT();
    }
}