using BenchmarkDotNet.Attributes;

public class ListBenchmark
{
    private const int NumberOfElements = 10000;

    [Benchmark]
    public void AddToDynamicList()
    {
        List<int> dynamicList = new List<int>(); // Dynamic list
        for (int i = 0; i < NumberOfElements; i++)
        {
            dynamicList.Add(i);
        }
    }

    [Benchmark]
    public void AddToPreSizedList()
    {
        List<int> preSizedList = new List<int>(NumberOfElements); // Pre-sized list
        for (int i = 0; i < NumberOfElements; i++)
        {
            preSizedList.Add(i);
        }
    }
}
