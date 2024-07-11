using BenchmarkDotNet.Attributes;


[MemoryDiagnoser]
public class ObjectPoolingBenchmarkExample
{
    static string currentDateAsString = null;

    [GlobalSetup]
    public void GlobalSetup()
    {
        currentDateAsString = DateTime.Now.ToShortDateString();
    }

    [Benchmark(Baseline = true)]
    public void ExtractUsingSubstring()
    {
        var day = currentDateAsString.Substring(0, 2);
        var month = currentDateAsString.Substring(3, 2);
        var year = currentDateAsString.Substring(6, 4);
    }

    [Benchmark]
    public void ExtractUsingSpan()
    {
        ReadOnlySpan<char> currentDateSpan = currentDateAsString;
        var day = currentDateSpan.Slice(0, 2);
        var month = currentDateSpan.Slice(3, 2);
        var year = currentDateSpan.Slice(6, 4);
    }
}
