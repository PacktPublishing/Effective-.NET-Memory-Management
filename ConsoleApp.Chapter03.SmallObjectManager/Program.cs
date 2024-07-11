namespace ConsoleApp.Chapter03.SmallObjectManager;

public class SmallObjectManager
{
    // Each array size is set to a value that won't be allocated on the LOH.
    private const int MaxArraySize = 20_000; // size * sizeof(int) < 85,000 bytes for int
    private List<int[]> arrays = new List<int[]>();

    public void AddData(IEnumerable<int> data)
    {
        int[] currentArray = null;
        int currentIndex = 0;

        foreach (var item in data)
        {
            // Allocate a new array when needed.
            if (currentArray == null || currentIndex >= MaxArraySize)
            {
                currentArray = new int[MaxArraySize];
                arrays.Add(currentArray);
                currentIndex = 0;
            }

            currentArray[currentIndex++] = item;
        }
    }

    public IEnumerable<int> GetData()
    {
        foreach (var array in arrays)
        {
            foreach (var item in array)
            {
                yield return item;
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        SmallObjectManager manager = new SmallObjectManager();
        // Example: Adding a large amount of data in chunks
        manager.AddData(GenerateLargeDataSet());
        // Retrieve and process the data
        foreach (var item in manager.GetData())
        {
            // Process each item
            Console.WriteLine(item);
        }
    }
    // Simulate generating a large set of data
    private static IEnumerable<int> GenerateLargeDataSet()
    {
        const int largeSize = 100_000;
        for (int i = 0; i < largeSize; i++)
        {
            yield return i;
        }
    }
}