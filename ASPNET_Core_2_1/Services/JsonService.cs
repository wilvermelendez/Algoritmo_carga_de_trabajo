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
        
        public bool SaveJson<T>(List<T> data, string path) where T : class
        {
            try
            {
                path = Path.GetDirectoryName(Path.GetFullPath("DatosGrafica.json")) + path;
                var json = JsonConvert.SerializeObject(data.ToArray());
                //write string to file
                File.WriteAllText(path, string.Empty);
                File.WriteAllText(path, json);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool SaveJson<T>(T data, string path) where T : class
        {
            try
            {
                path = Path.GetDirectoryName(Path.GetFullPath("DatosGrafica.json")) + path;
                var json = JsonConvert.SerializeObject(data);
                //write string to file
                File.WriteAllText(path, string.Empty);
                File.WriteAllText(path, json);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
