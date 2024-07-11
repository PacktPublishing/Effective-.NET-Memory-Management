using StackExchange.Redis;

namespace Caching.Api.Chapter08;

public class RedisConnection
{
    private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
    {
        // Replace with your actual Redis connection string
        return ConnectionMultiplexer.Connect("locahost:6379,password=password");
    });

    public static ConnectionMultiplexer Connection => lazyConnection.Value;
}
