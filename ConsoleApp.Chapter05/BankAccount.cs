public class BankAccount
{
    private object balanceLock = new object();
    public int Balance { get; private set; }

    // Constructor to initialize the bank account with a balance
    public BankAccount(int startingBalance)
    {
        Balance = startingBalance;
    }

    // Method to deposit money into the account
    public void Deposit(int amount)
    {
        //Locking to ensure only one thread can enter this code block at a time
        lock (balanceLock)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entering deposit.");
            int initialBalance = Balance;
            Balance += amount;
            Console.WriteLine($"Deposited {amount}. Initial balance was {initialBalance}. New balance is {Balance}.");
        }
    }
}
