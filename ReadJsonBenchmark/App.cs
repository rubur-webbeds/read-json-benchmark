using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Caching.Memory;

namespace ReadJsonBenchmark
{
    public class App
    {
        private readonly IMemoryCache _cache;

        public App(IMemoryCache cache)
        {
            _cache = cache;

            SaveJsonOnCache("Lorem", ReadJsonFromDisk("lorem_min.json"));
        }

        public void SaveJsonOnCache(string cacheKey, string file)
        {
            _cache.Set<string>(cacheKey, file);
        }

        public string ReadJsonFromCache(string cacheKey)
        {
            return _cache.Get<string>(cacheKey);
        }

        public string ReadJsonFromDisk(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
