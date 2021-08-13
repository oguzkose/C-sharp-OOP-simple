class EmailLogger : ILogger
{
    public void WriteLogger()
    {
        System.Console.WriteLine("E-Mail olarak Log yazıldı");
    }
}