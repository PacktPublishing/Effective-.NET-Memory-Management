Console.WriteLine("Memory Leak Demo");
var leaker = new MemoryLeaker();
for (int i = 0; i < 10; i++)
{
    leaker.LeakMemory();
    Console.WriteLine($"Iteration {i + 1}: Leaked 10MB");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
