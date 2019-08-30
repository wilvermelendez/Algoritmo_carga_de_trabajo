using ASPNET_Core_2_1.Models;
using System.Collections.Generic;

namespace ASPNET_Core_2_1.Services
{
    public class WorkLoadService
    {
        public IJsonService JsonService { get; set; }

        public WorkLoadService(IJsonService jsonService)
        {
            JsonService = jsonService;
        }

        public List<WorkLoad> GetWorkLoads()
        {
            return null;
        }

        public bool SaveWorkLoad()
        {
            return true;

        }
    }
}
