using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Immutable;

public class CollectionBenchmark
{
    private const int N = 1000;

    [Benchmark]
    public void AddToList()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < N; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void AddToArray()
    {
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            array[i] = i;
        }
    }

    [Benchmark]
    public void AddToConcurrentBag()
    {
        ConcurrentBag<int> bag = new ConcurrentBag<int>();
        for (int i = 0; i < N; i++)
        {
            bag.Add(i);
        }
    }

    [Benchmark]
    public void AddToImmutableList()
    {
        ImmutableList<int> immutableList = ImmutableList<int>.Empty;
        for (int i = 0; i < N; i++)
        {
            immutableList = immutableList.Add(i);
        }
    }

    [Benchmark]
    public void IterateList()
    {
        List<int> list = new List<int>(Enumerable.Range(0, N));
        foreach (var item in list) { }
    }

    [Benchmark]
    public void IterateArray()
    {
        int[] array = Enumerable.Range(0, N).ToArray();
        foreach (var item in array) { }
    }

    [Benchmark]
    public void IterateConcurrentBag()
    {
        ConcurrentBag<int> bag = new ConcurrentBag<int>(Enumerable.Range(0, N));
        foreach (var item in bag) { }
    }

    [Benchmark]
    public void IterateImmutableList()
    {
        ImmutableList<int> immutableList = ImmutableList.CreateRange(Enumerable.Range(0, N));
        foreach (var item in immutableList) { }
    }
}
