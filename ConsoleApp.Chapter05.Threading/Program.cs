using System;

namespace ConsoleApp.Chapter05.Threading;

public class Program
{
    public static void Main()
    {
        var singleThreadedSum = new SingleThreadedSum();
        var multiThreadedSum = new MultiThreadedSum();
        singleThreadedSum.Main();
        multiThreadedSum.Main();
    }
}