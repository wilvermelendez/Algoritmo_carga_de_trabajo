using System.Collections.Generic;

namespace ASPNET_Core_2_1.Services
{
    public interface IJsonService
    {
        List<T> LoadJson<T>(string path) where T : class;
    }
}