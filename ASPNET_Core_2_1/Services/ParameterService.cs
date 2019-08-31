using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Core_2_1.Models;

namespace ASPNET_Core_2_1.Services
{
    public class ParameterService : IParameterService
    {
        public IJsonService JsonService { get; set; }

        public ParameterService(IJsonService jsonService)
        {
            JsonService = jsonService;
        }

        public bool SaveParameters(Parameter parameter)
        {
            //List<Parameter> parameters = new List<Parameter>();

            JsonService.SaveJson<Parameter>(parameter, "/Data/parametros.json");
            return true;
        }

        public List<Parameter> GetParameters()
        {

            return null;
        }

    }
}
