using System.Net.Mail;
using System.Net;

public class Broadcasting
{
    List<EmailDetails> mailBroad = new();

    public Broadcasting(List<EmailDetails> mailList)
    {
        mailBroad = mailList;
    }

    public void Broadcast()
    {
        List<string> emailList = new List<string>();

        Console.WriteLine("Please enter the subject of the email:");
        var subject = Console.ReadLine();
        if(string.IsNullOrEmpty(subject))
        {
            Console.WriteLine("Subject can't be empty! \tPlease enter the subject");
            subject = Console.ReadLine();
        }

        Console.WriteLine("Please enter the body of the email(Press (CTRL + Z and enter) for ending the body part): ");
        var message = Console.In.ReadToEnd();

        List<Thread> threads = new List<Thread>();

        foreach (var thread in mailBroad)
        {
            emailList.Add(thread.Email);
        }

        foreach (string email in emailList)
        {
            Thread thrd = new Thread(() => SendEmail(email, subject, message));
            threads.Add(thrd);
        }

        foreach (Thread thread in threads)
        {
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("Process done!!");
    }

    static void SendEmail(string toAddress, string subject, string message)
    {
        string fromAddress = "yourgmail@gmail.com";

        MailMessage mail = new MailMessage(fromAddress, toAddress);
        mail.Subject = subject;
        mail.Body = message;
        mail.IsBodyHtml = true;

        //Generate this one with the help of setting of your account.
        NetworkCredential NetworkCred = new NetworkCredential("yourgmail@gmail.com", "Your_Credential_Password");

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = NetworkCred;
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Send(mail);
        Console.WriteLine($"Email sent to {toAddress}");
    }
}
