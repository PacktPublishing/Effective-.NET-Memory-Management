using System.Collections.Concurrent;

var safeNumbers = new ConcurrentBag<int>();

Task safeTask1 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        safeNumbers.Add(i);
    }
});

Task safeTask2 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        safeNumbers.Add(i);
    }
});

Task.WaitAll(safeTask1, safeTask2);
Console.WriteLine($"Total count: {safeNumbers.Count}");  // This will be 2000
