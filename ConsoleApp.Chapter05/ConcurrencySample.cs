using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ConsoleApp.Chapter05;

public class ConcurrencySample
{
    public async Task ManageParallelList()
    {

        List<Data> dataList = GetDataList();
        ConcurrentBag<Result> results = new ConcurrentBag<Result>();

        //Create an instance of ParallelOptions
        ParallelOptions options = new ParallelOptions();
        options.MaxDegreeOfParallelism = 2; // Adjust the degree of parallelism as needed

        //Execute the Parallel.ForEach loop with the specified options
        Parallel.ForEach(dataList, options, data =>
        {
            Result result = ProcessData(data);
            results.Add(result);
        });

    }

    private List<Data> GetDataList()
    {
        return new List<Data>();
    }

    private Result ProcessData(Data data)
    {
        Task.Delay(1000).Wait();
        return new Result();
    }
}

public class Data
{
    public int Id { get; set; }
}

public class Result
{

}
