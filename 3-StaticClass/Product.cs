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