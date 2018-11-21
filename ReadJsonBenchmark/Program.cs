using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace ReadJsonBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddMemoryCache()
                .AddSingleton<App>()
                .AddSingleton<IJsonReader, JsonReader>()
                .BuildServiceProvider();

            serviceProvider.GetService<App>().Execute();
        }

    }
}
