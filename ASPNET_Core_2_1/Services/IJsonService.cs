﻿using System.Collections.Generic;

namespace ASPNET_Core_2_1.Services
{
    public interface IJsonService
    {
        List<T> LoadJson<T>(string path) where T : class;
        T LoadSingleJson<T>(string path) where T : class;
        bool SaveJson<T>(List<T> data, string path) where T : class;
        bool SaveJson<T>(T data, string path) where T : class;
    }
}