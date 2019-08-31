using System.Collections.Generic;
using ASPNET_Core_2_1.Models;

namespace ASPNET_Core_2_1.Services
{
    public interface IParameterService
    {
        bool SaveParameters(Parameter parameter);
        Parameter GetParameters();
    }
}