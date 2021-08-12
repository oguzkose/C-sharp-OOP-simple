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
    public void RaiseTheGrade()
    {
        Grade = Grade + 20;
    }
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