using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using DotNetEveryDay.Extensions.Extensions;

namespace DotNetEveryDay.Benchmark;

public class Program
{
    public static void Main()
    {
        var config = new ManualConfig();
        config.AddJob(Job.ShortRun);
        config.AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
        config.AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
        config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
        BenchmarkRunner.Run(typeof(Program).Assembly, config);
    }
}

[MemoryDiagnoser(false)]
[SimpleJob(RunStrategy.ColdStart)]
public class BenchmarkMethods
{
    [Params("the minimum observed iteration time is 1.9590 us which is very small." +
            " It's recommended to increase it to at least 100.0000 ms using more operations.",
        "The minimum observed iteration time is 1.9590 us which is very small." +
        "It's recommended to increase it to at least 100.0000 ms using more operations." )]

    public string? SomeString { get; set; }
        
    
    [Benchmark]
    public void ToLowerStart()
    {
        
    }
        
    [Benchmark]
    public void ToLowerStart_Op()
    {
        
    }
}