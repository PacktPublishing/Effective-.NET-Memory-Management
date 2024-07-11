using BenchmarkDotNet.Running;


BenchmarkRunner.Run<StructVsClassesBenchamarks>();
BenchmarkRunner.Run<CollectionBenchmark>();
BenchmarkRunner.Run<ListBenchmark>();
BenchmarkRunner.Run<ContiguousMemoryBenchmark>();

