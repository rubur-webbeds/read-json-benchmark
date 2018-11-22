using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Caching.Memory;

namespace ReadJsonBenchmark
{
    public class JsonReader
    {
        private readonly IMemoryCache _cache;

        public JsonReader(IMemoryCache cache)
        {
            _cache = cache;
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
