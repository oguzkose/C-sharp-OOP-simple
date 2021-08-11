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

## Encapsulation(Kapsülleme)
- Bir class'a ait property'lerin, başka bir class veya end user tarafından değiştirilmesinin sınırlandırılması için o property'ler kapsüllenir, sınırları belirlenir.
- Encapsulation kısaca property'lerin setter metotlarında yapılan değişikliklerle kapsülleyerek, o property'lere erişimin sınırlandırılması demektir.

Student.cs
```csharp
    class Student
{
    //Properties
    public string Name { get; set; }
    public string Surname { get; set; }

    //Encapsulation
    private int _grade;
    public int Grade
    {
        get { return _grade; }
        set
        {
            if (value < 0)
            {
                System.Console.WriteLine("Not sıfırdan küçük olamaz");
            }
            else
            {
                _grade = value;
            }
        }
    }
    //Constructor
    public Student(string name, string surname, int grade)
    {
        this.Name = name;
        this.Surname = surname;
        this.Grade = grade;
    }
    //Methods
    public void DownGrade()
    {
        Grade = Grade - 20;
    }
    public void PrintStudentInfo()
    {
        System.Console.WriteLine("Isim :" + " " + this.Name);
        System.Console.WriteLine("Soyisim :" + " " + this.Surname);
        System.Console.WriteLine("Not :" + " " + this.Grade);
    }
}
```

Program.cs
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            
            Student student = new Student("Oğuz","Köse",21);
            student.PrintStudentInfo();//Output: Not:21

            student.DownGrade();
            student.PrintStudentInfo();//Output: Not:1
            
            student.DownGrade();
            student.PrintStudentInfo();//Output: Not sıfırdan küçük olamaz Not:1             
        }
    }
```