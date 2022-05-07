using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using DotNetEveryDay.Extensions.Extensions;

namespace DotNetEveryDay.Benchmark;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
    }

    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MedianColumn, StdErrorColumn]
    [SimpleJob(RunStrategy.Monitoring)]
    public class BenchmarkMethods
    {
        private static IEnumerable<MyClass> CreateCollection(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if(i == count/2)
                    yield return new MyClass() {SomeName = count + "" + i};
                else
                    yield return new MyClass() {SomeName = count + "" + (i - 1)};
            }
        }
        
        [Params(100000, 1000000)]
        public int Count { get; set; }
        
        [Benchmark]
        public void HasDuplicates()
        {
            var collection = CreateCollection(Count);
            collection.HasDuplicates(x => x.SomeName);
        }
        
        private class MyClass
        {
            public string SomeName { get; init; }
        }
    }
}