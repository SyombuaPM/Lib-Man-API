namespace CityInfo_API.Sercices;

public class LocalMailService
{
    private string _mailTo = "admin@mycompany.com";
    private string _mailFrom = "noreply@mycompany.com";

    public void Send(string subject, string message)
    {
        //send mail - output to debug window
        Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Messag: {message}");
    }


}
