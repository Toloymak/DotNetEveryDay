using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

namespace DotNetEveryDay.Benchmark;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
    }

    [SimpleJob(RunStrategy.Throughput)]
    public class BenchmarkMethods
    {
        [Benchmark]
        public void FSharp()
        {
            
        }

        [Benchmark]
        public void CSharp()
        {
        }
    }
}