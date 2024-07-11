static class Program
{
    static void Main()
    {
        int num1 = 3;
        int num2 = num1;
        num1 = 5;
        Console.WriteLine($"num1: {num1}");
        Console.WriteLine($"num2: {num2}");

        Person nobody; // null reference
        Person arthur = new Person("Arthur", "Wint", new DateOnly(2001, 10, 25)); // create variable to reference to Person object 
        Person james = arthur; // copy Person object location
        james.FirstName = "James";
        string jamesFullName = $"{james.FirstName} {james.LastName}";
        string arthurFullName = $"{arthur.FirstName} {arthur.LastName}";
        Console.WriteLine($"James Full name: {jamesFullName}");
        Console.WriteLine($"Arthur Full name: {arthurFullName}");
    }
}