class Employee
{
    //Properties
    public int Number { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    //Constructor
    public Employee(int number, string name, string surname)
    {
        this.Number = number;
        this.Name = name;
        this.Surname = surname;
    }
    //Constructor-Overloading
    public Employee(string name,string surname)
    {
        this.Name=name;
        this.Surname=surname;
    }
}