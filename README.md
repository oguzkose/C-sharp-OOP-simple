# OBJECT ORIENTED PROGRAMMING(Nesne Yönelimli Programlama)
## Static Class
- Static bir class'ın tüm elemanları(field , property ,metot) static olmalıdır.
- Static classların instance'i alınamaz. Class ismi ile elemanlarına erişilebilir.
- Static olmayan bir sınıfın elemanlarına başka sınıflardan instance aracılığıyla erişilebilir ancak varsa static elemanlarına class ismi ile erişilir.
- Static constructor'ler yazılabilir ancak erişim belirleyicileri olmaz.

Product.cs
```csharp
    public class Product
    {
        public int Id { get; set; }
        static public string Name;
        static public string Surname { get; set; }
        static public void Print()
        {
            //static metot içinde static prop ve fieldlara erişilebildi ancak static olmayan Id property'sine erişilemedi.
            System.Console.WriteLine(Name + Surname);
        }

        // Static Constructor
        static Product()
        {

        }
    }
```
Program.cs
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            //Product class'i static olarak işaretlenmediği için instance'i alınabilir.Aksi durumda Product class'ina instance ile değil class ismi ile erişilebilirdi.
            Product product = new Product();

            //Id property'si static olmadığı için instance ile erişilebilir
            product.Id = 1;

            //Name field'i ve Surname property'si static olarak işaretlendiği için direct olarak ait oldukları class'ın ismi ile erişilebilirç
            Product.Name = "Oğuz";
            Product.Surname = "Köse";
        }
    }
```

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
- Bir class'a ait field'lar, başka bir class veya end user tarafından değiştirilmesinin sınırlandırılması için public property'ler ile kapsüllenir, sınırları belirlenir.
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
## Inheritance(miras)
- Bir derived class'ın kendini kapsayan base class'tan inherit edilmesidir.
- Base class'a ait tüm property'ler ve metotlara , base class'tan miras almış tüm derived class'lar ulaşabilir.

LivingThings.cs
```csharp
    //Base Class
    class LivingThings 
    {
        public string Family { get; set; }
        public string Color { get; set; }
    }
```
Animals.cs
```csharp
    //Derived Class
    class Animals:LivingThings 
    {
        public void Move()
        {
            System.Console.WriteLine("Hayvanlar hareket eder");
        }
    }
```
Plants.cs
```csharp
    //Derived Class
    class Plants : LivingThings
    {
        public void Photosynthesize()
        {
            System.Console.WriteLine("Bitkiler fotosentez yapar");
        }
    }
```
Program.cs
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            Animals tiger = new();

            //Move() metotu animals class'ından gelir
            tiger.Move();
            // Family,Color Base Class(LivingThings)'a ait özelliklerdir 
            tiger.Family="Memeli";
            tiger.Color="Kahverengi";



            Plants pineTree = new();

            //Photosynthesize() metotu plants class'ından gelir
            pineTree.Photosynthesize();
            // Family,Color Base Class(LivingThings)'a ait özelliklerdir
            pineTree.Family="Iğne yapraklılar";
            pineTree.Color="Green";
        }
    }            
```