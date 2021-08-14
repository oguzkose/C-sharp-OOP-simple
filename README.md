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

## Polymorphism(Çokbiçimlilik)
- Polymorphism : base class'ta ki metotlara virtual keyword'u ekleyerek, o metotları sanallaştırmaktır. Derived class'larda bu metot override keywordu ile ezilir-biçimi değiştirilir.
- Kısaca base class'ta yazılmış bir metot derived class'larda, aynı metot ismiyle farklı çıktılar verebilir.

Person.cs
```csharp
    class Person
    {
        //Virtual
        public string Name { get; set; }
        
        virtual public void sayGoodMorning()
        {
            System.Console.WriteLine("Günaydın");
        }
    }
```
German.cs
```csharp
    class German:Person
    {
        //Override
        public override void sayGoodMorning()
        {
            base.sayGoodMorning(); //Virtual ile işaretlenen metot(base'den gelen)
            System.Console.WriteLine("Guten Morgen!");//Metotun override    edilmesiyle düzenlenmiş hali
        }
    }
```

French.cs
```csharp
    class French:Person
    {
        public override void sayGoodMorning()
        {
            base.sayGoodMorning();
            System.Console.WriteLine("Bon Matin!");
        }
    }
```
Program.cs
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            German germanPeople = new();
            germanPeople.sayGoodMorning();//Output: Guten Morgen!

            French frenchPeople=new();
            frenchPeople.sayGoodMorning();//Output: Bon Matin!
        }
    }
```

## Interface
- Class'ların içermesi gereken metotlarının imzalarının bulunduğu bir taslak niteliğindedir.
- Interface yapısında metotların gövdesi yazılmaz. void veya geri dönüş tipi ve metotun ismi yazılır.
- Inheritance yolu ile class'lara verilir. Implement edilmesi zorunludur.
- Implement edildikten sonra class içerisinde metotların gövdesi yazılır.
- Instance'i alınamaz. Referans tiptedir , Heap'te barınır.

ILogger.cs
```csharp
    interface ILogger
    {
        void WriteLogger();
    }
```
EmailLogger.cs
```csharp
    class EmailLogger : ILogger
    {
        public void WriteLogger()
        {
            System.Console.WriteLine("E-Mail olarak Log yazıldı");
        }
    }
}
```
SmsLogger.cs
```csharp
    class SmsLogger : ILogger
    {
        public void WriteLogger()
        {
            System.Console.WriteLine("Sms olarak Log yazıldı");
        }
    }
```
Program.cs
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            EmailLogger emailLogger = new();
            emailLogger.WriteLogger();//Output:E-Mail olarak Log yazıldı

            SmsLogger smsLogger = new();
            smsLogger.WriteLogger();//Output:Sms olarak Log yazıldı
        }
    }
```
## Abstract Class
- Abstract class'lar normal class'lara çok benzer. Ancak Instance'i alınmaz Inheritance ile diğer class'lara implement edilmesi zorunludur.
- Abstract class'lar gövdelerinde abstract olmayan metotlar ve property'ler de barındırabilir. Abstract metotların gövdesi yazılmaz.
- Abstact class'a ait abstract metotlar implemente edildikleri class'larda override edilmelidir.
- RAM'in Heap bölümünde tutulurlar. Referans adresleri Stack'tedir.

Car.cs
```csharp
    public abstract class Car
    {
        //Araba modelleri için marka adını dönecek olan abstract metot
        public abstract Brand GetBrandName();

        //(Polymorphism) Virtual ile işaretlendiği için defaultta Blue dönecek  ancak override edilirse Red döndürülebilir.
        public virtual Color GetColorName()
        {
            return Color.Blue;
        }
        //Her araba için tekerlek sayısı 4 dönecek.
        public int HowManyWheels()
        {
            return 4;
        }
    }
```
Enums.cs
```csharp
    public enum Brand
    {
        Honda,
        Toyota
    }
    public enum Color
    {
        Blue,
        Red
    }
```
Civic.cs
```csharp
    class Civic : Car
    {
        public override Brand GetBrandName()
        {
            return Brand.Honda;
        }
        public override Color GetColorName()
        {
            return Color.Red;
        }
    }
```
Corolla.cs
```csharp
    class Corolla : Car
    {
        public override Brand GetBrandName()
        {
            return Brand.Toyota;
        }
    }
```
Program.cs
```csharp
    class Program
    {
        static void Main(string[] args)
        {
            Corolla corolla = new();
            System.Console.WriteLine(corolla.HowManyWheels());//Output: 4
            System.Console.WriteLine(corolla.GetColorName());//Output: Blue
            System.Console.WriteLine(corolla.GetBrandName());//Output: Toyota

            Civic civic = new();
            System.Console.WriteLine(civic.HowManyWheels());//Output: 4
            System.Console.WriteLine(civic.GetColorName());//Output: Red
            System.Console.WriteLine(civic.GetBrandName());//Output: Honda
        }
    }          
```