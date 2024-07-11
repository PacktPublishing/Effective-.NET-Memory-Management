using BenchmarkDotNet.Attributes;

public class StructVsClassesBenchamarks
{

    const int items = 100000;

    [GlobalSetup]
    public void GlobalSetup()
    {
        //Write your initialization code here
    }

    [Benchmark]
    public void CreatingInstancesUsingClass()
    {
        MyClass[] myClassArray = new MyClass[items];
        for (int i = 0; i < items; i++)
        {
            myClassArray[i] = new MyClass();
        }
    }

    [Benchmark]
    public void CreatingInstancesUsingStruct()
    {
        MyStruct[] myStructArray = new MyStruct[items];
        for (int i = 0; i < items; i++)
        {
            myStructArray[i] = new MyStruct();
        }
    }

}
class MyClass
{
    public double Num1 { get; set; }
    public double Num2 { get; set; }
    public double Num3 { get; set; }
}

struct MyStruct
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}