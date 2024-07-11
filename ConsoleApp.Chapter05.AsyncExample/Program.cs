namespace ConsoleApp.Chapter05.AsyncExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncCounter counter = new AsyncCounter();

            // Create an array of tasks to demonstrate concurrent increments
            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(async () =>
                {
                    await counter.IncrementAsync();
                    Console.WriteLine($"Count after increment: {await counter.GetCountAsync()}");
                });
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);

            // Final count
            Console.WriteLine($"Final count: {await counter.GetCountAsync()}");
        }
    }
}
