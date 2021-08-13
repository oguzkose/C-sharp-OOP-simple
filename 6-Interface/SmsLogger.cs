class SmsLogger : ILogger
{
    public void WriteLogger()
    {
        System.Console.WriteLine("Sms olarak Log yazıldı");
    }
}