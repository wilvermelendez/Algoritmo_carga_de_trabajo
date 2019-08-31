using ASPNET_Core_2_1.Models;
using System.Collections.Generic;
using System.IO;

namespace ASPNET_Core_2_1.Services
{
    public class DemandService : IDemandService
    {
        public IJsonService JsonService { get; set; }

        public DemandService(IJsonService jsonService)
        {
            JsonService = jsonService;
        }

        public List<Demand> GetDemands() => JsonService.LoadJson<Demand>("/Data/DatosGrafica.json");
        public List<DemandDT> GetDemandsDT() => JsonService.LoadJson<DemandDT>("/Data/LlenarDT.json");
    }
}
