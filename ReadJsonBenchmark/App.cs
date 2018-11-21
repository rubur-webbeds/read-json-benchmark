using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadJsonBenchmark
{
    public class App
    {
        private readonly IJsonReader _reader;

        public App(IJsonReader reader)
        {
            _reader = reader;

            _reader.SaveJsonOnCache("Lorem", _reader.ReadJsonFromDisk("lorem_min.json"));
        }

        [Benchmark]
        public void ReadDisk()
        {
            _reader.ReadJsonFromDisk("lorem_min.json");
        }

        [Benchmark]
        public void ReadCache()
        {
            _reader.ReadJsonFromCache("Lorem");
        }

        public void Execute()
        {
            var summary = BenchmarkRunner.Run<App>();
            Console.ReadKey();
        }

    }
}
