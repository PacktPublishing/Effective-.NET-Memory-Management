public class BankAccountWithMonitor
{
    private int balance;
    private readonly object balanceLock = new object();

    // Constructor to initialize the bank account with a balance
    public BankAccountWithMonitor(int initialBalance)
    {
        balance = initialBalance;
    }

    // Property to safely access balance
    public int Balance
    {
        get
        {
            lock (balanceLock)
            {
                return balance;
            }
        }
        private set
        {
            lock (balanceLock)
            {
                balance = value;
            }
        }
    }

    //Method to deposit money into the account
    public void Deposit(int amount)
    {
        bool lockTaken = false;
        try
        {
            //Try to enter the lock

           Monitor.TryEnter(balanceLock, ref lockTaken);
            if (lockTaken)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entering deposit.");
                int initialBalance = Balance;
                Balance += amount;
                Console.WriteLine($"Deposited {amount}. Initial balance was {initialBalance}. New balance is {Balance}.");
            }
            else
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} could not enter deposit method.");
            }
        }
        finally
        {
            //Ensure the lock is released
            if (lockTaken)
                {
                    Monitor.Exit(balanceLock);
                }
        }
    }
}
