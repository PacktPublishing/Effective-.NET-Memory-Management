namespace ConsoleApp.Chapter05;

public class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(1000);

        //Create multiple threads to simulate deposit
        Thread thread1 = new Thread(() => account.Deposit(500));
        Thread thread2 = new Thread(() => account.Deposit(300));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine($"Final balance is {account.Balance}.");


        BankAccountWithMonitor accountWithMonitor = new BankAccountWithMonitor(1000);
        //Create multiple threads to simulate deposit
        Thread thread3 = new Thread(() => accountWithMonitor.Deposit(500));
        Thread thread4 = new Thread(() => accountWithMonitor.Deposit(300));

        thread3.Start();
        thread4.Start();

        thread3.Join();
        thread4.Join();

        Console.WriteLine($"Final balance is {accountWithMonitor.Balance}.");


        BankAccountWithMutex accountWithMutex = new BankAccountWithMutex(1000);

        //Create multiple threads to simulate deposit
        Thread thread5 = new Thread(() => accountWithMutex.Deposit(500));
        Thread thread6 = new Thread(() => accountWithMutex.Deposit(300));

        thread5.Start();
        thread6.Start();

        thread5.Join();
        thread6.Join();

        Console.WriteLine($"Final balance is {accountWithMutex.Balance}.");


        Task<int> task = Task.Run(() => ComputeResult());
        Console.WriteLine($"Result: {task.Result}");
    }

    private static int ComputeResult()
    {
        //Simulate some computation
        return new Random().Next(100);
    }
}





