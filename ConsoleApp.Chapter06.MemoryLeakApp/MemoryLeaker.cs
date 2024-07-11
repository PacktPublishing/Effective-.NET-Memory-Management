
public class MemoryLeaker
{
    private List<byte[]> leakingList = new List<byte[]>();

    public void LeakMemory()
    {
        // Each call leaks approximately 10MB of memory.
        byte[] data = new byte[10 * 1024 * 1024]; // Allocate 10 MB
        leakingList.Add(data);
    }

    // Intentionally not freeing the memory
}