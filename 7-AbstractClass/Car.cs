public abstract class Car
{
    //Araba modelleri için marka adını dönecek olan abstract metot
    public abstract Brand GetBrandName();

    //(Polymorphism) Virtual ile işaretlendiği için defaultta Blue dönecek ancak override edilirse Red döndürülebilir.
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