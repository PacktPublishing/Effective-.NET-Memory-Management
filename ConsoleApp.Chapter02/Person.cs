public class Person
{
    // Constructor method
    public Person(string firstName, string lastName, DateOnly dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        _age = DateTime.Now.Year - dateOfBirth.Year;
    }

    // Attributes - Properties and fields
    public string FirstName { get; set; } // property - public access
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    private int _age; // field - not publicly accessible

    // Methods
    public double GetAge()
    {
        return _age;
    }
}
