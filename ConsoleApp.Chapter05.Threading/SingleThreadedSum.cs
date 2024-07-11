using System;

public class SingleThreadedSum
{
    public void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        long sum = SumArray(numbers);
        Console.WriteLine($"The sum of the array is: {sum}");
    }

    private long SumArray(int[] numbers)
    {
        long sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum;
    }
}

