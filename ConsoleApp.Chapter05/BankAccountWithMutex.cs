public class BankAccountWithMutex
{
    private int balance;
    private static Mutex mutex = new Mutex();

    //Constructor to initialize the bank account with a balance
    public BankAccountWithMutex(int initialBalance)
    {
        balance = initialBalance;
    }

    //Property to safely access balance
    public int Balance
    {
        get
        {
            mutex.WaitOne(); // Acquire the mutex
            int temp = balance;
            mutex.ReleaseMutex(); // Release the mutex
            return temp;
        }
        private set
        {
            mutex.WaitOne(); // Acquire the mutex
            balance = value;
            mutex.ReleaseMutex(); // Release the mutex
        }
    }

    //Method to deposit money into the account
    public void Deposit(int amount)
    {
        mutex.WaitOne(); // Acquire the mutex before entering critical section
        try
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entering deposit.");
            int initialBalance = Balance;
            Balance += amount;
            Console.WriteLine($"Deposited {amount}. Initial balance was {initialBalance}. New balance is {Balance}.");
        }
        finally
        {
            mutex.ReleaseMutex(); // Always release the mutex in finally block
        }
    }
}
