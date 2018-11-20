using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace ReadJsonBenchmark
{
    class Program
    {
        private static IMemoryCache _cache;

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddMemoryCache()
                .BuildServiceProvider();

            _cache = serviceProvider.GetService<IMemoryCache>();

            var summary = BenchmarkRunner.Run<Program>();
        }

        static Program()
        {
            SaveJsonOnCache("Lorem", ReadJsonFromDisk("lorem_min.json"));
        }

        public static void SaveJsonOnCache(string cacheKey, string file)
        {
            _cache.Set<string>(cacheKey, file);
        }

        [Benchmark]
        public static string ReadJsonFromCache(string cacheKey)
        {
            return _cache.Get<string>(cacheKey);
        }

        [Benchmark]
        public static string ReadJsonFromDisk(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
