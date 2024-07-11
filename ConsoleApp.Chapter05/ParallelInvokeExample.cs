namespace ConsoleApp.Chapter05;

public class ParallelInvokeExample
{
    public void Demo()
    {
        Parallel.Invoke(
            () => Console.WriteLine("Task 1"),
            () => Console.WriteLine("Task 2"),
            () => Console.WriteLine("Task 3")
        );

        Console.WriteLine("All tasks completed.");
    }
}
