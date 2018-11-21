using System;
using System.Collections.Generic;
using System.Text;

namespace ReadJsonBenchmark
{
    public interface IJsonReader
    {
        void SaveJsonOnCache(string cacheKey, string file);
        string ReadJsonFromCache(string cacheKey);
        string ReadJsonFromDisk(string path);
    }
}
