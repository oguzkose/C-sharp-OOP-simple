# OBJECT ORIENTED PROGRAMMING(Nesne Yönelimli Programlama)
## Constructor (Yapıcı&Kurucu Metot)
- Constructor ; bir Class'ın instance'i alınırken arka tarafta çalışan kurucu&yapıcı metottur. Erişim belirteci Public olur, geriye değer döndürmez, ait olduğu Class'ın ismi ile aynı isme sahip olmalıdır.
- Constructor'a method overloading(Aşırı yükleme) yapılabilir.

Employee.cs
```csharp
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
```

Program.cs
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee(1, "Oğuz", "Köse");
            System.Console.WriteLine(employee.Number + " " + employee.Name + " " + employee.Surname);//Output: 1 Oğuz Köse 

            Employee employee2 =new Employee("James","Hetfield");
            Console.WriteLine(employee2.Name + " " + employee2.Surname);//Output: James Hetfield
        }
    }
```