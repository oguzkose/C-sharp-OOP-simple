class German:Person
{
    //Override
    public override void sayGoodMorning()
    {
        base.sayGoodMorning(); //Virtual ile işaretlenen metot(base'den gelen)
        System.Console.WriteLine("Guten Morgen!");//Metotun override edilmesiyle düzenlenmiş hali
    }
}