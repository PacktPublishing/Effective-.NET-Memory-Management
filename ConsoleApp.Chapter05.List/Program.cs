var numbers = new List<int>();

Task task1 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        numbers.Add(i);
    }
});

Task task2 = Task.Run(() =>
{
    for (int i = 0; i < 1000; i++)
    {
        numbers.Add(i);
    }
});

Task.WaitAll(task1, task2);
Console.WriteLine($"Total count: {numbers.Count}");  // This may not be 2000!
