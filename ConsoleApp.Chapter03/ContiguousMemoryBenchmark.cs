using BenchmarkDotNet.Attributes;

public class ContiguousMemoryBenchmark
{
    private int[] numbers;
    private const int Size = 10000;

    [GlobalSetup]
    public void Setup()
    {
        // Initialize the array with sample data
        numbers = new int[Size];
        for (int i = 0; i < Size; i++)
        {
            numbers[i] = i;
        }
    }

    [Benchmark]
    public int SumWithArray()
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    [Benchmark]
    public int SumWithSpan()
    {
        Span<int> span = new Span<int>(numbers);
        int sum = 0;
        for (int i = 0; i < span.Length; i++)
        {
            sum += span[i];
        }
        return sum;
    }

    [Benchmark]
    public int SumWithMemory()
    {
        Memory<int> memory = new Memory<int>(numbers);
        int sum = 0;
        for (int i = 0; i < memory.Length; i++)
        {
            sum += memory.Span[i];
        }
        return sum;
    }
}