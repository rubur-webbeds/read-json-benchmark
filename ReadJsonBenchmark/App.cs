using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadJsonBenchmark
{
    public class App
    {
        private readonly JsonReader _reader;

        public App()
        {
            _reader = new JsonReader(new MemoryCache(new MemoryCacheOptions()));

            _reader.SaveJsonOnCache("Lorem", _reader.ReadJsonFromDisk("lorem_min.json"));
        }

        [Benchmark]
        public string ReadDisk()
        {
            return _reader.ReadJsonFromDisk("lorem_min.json");
        }

        [Benchmark]
        public string ReadCache()
        {
            return _reader.ReadJsonFromCache("Lorem");
        }

        public void Execute()
        {
            var summary = BenchmarkRunner.Run<App>();
            Console.ReadKey();
        }

    }
}
