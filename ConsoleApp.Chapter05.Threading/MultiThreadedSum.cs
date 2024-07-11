public class MultiThreadedSum
{
    public void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int numberOfThreads = 4; // Be wise when choosing this number. 
        long sum = SumArrayMultiThreaded(numbers, numberOfThreads);
        Console.WriteLine($"The sum of the array is: {sum}");
    }

    private long SumArrayMultiThreaded(int[] numbers, int numberOfThreads)
    {
        int lengthPerThread = numbers.Length / numberOfThreads;
        long totalSum = 0;
        List<Thread> threads = new List<Thread>();
        object lockObject = new object();

        for (int i = 0; i < numberOfThreads; i++)
        {
            int start = i * lengthPerThread;
            int end = (i == numberOfThreads - 1) ? numbers.Length : start + lengthPerThread;
            Thread thread = new Thread(() =>
            {
                long partialSum = 0;
                for (int j = start; j < end; j++)
                {
                    partialSum += numbers[j];
                }

                lock (lockObject)
                {
                    totalSum += partialSum;
                }
            });

            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join(); // Ensuring all threads complete before proceeding
        }

        return totalSum;
    }
}
