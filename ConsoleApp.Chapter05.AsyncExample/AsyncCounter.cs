namespace ConsoleApp.Chapter05.AsyncExample
{
    public class AsyncCounter
    {
        private int _count = 0;
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1); // Initial and maximum count is 1

        public async Task IncrementAsync()
        {
            await _semaphore.WaitAsync(); // Asynchronously wait until the semaphore is available
            try
            {
                _count++;
            }
            finally
            {
                _semaphore.Release(); // Release the semaphore
            }
        }

        public async Task<int> GetCountAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _count;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
