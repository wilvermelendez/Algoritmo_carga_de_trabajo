using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ASPNET_Core_2_1.Services
{
    public class JsonService : IJsonService
    {
        public List<T> LoadJson<T>(string path) where T : class
        {
            List<T> items;

            try
            {
                using (var r = new StreamReader(path))
                {
                    var json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<T>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return items;

        }
    }
}
