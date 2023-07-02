using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

public class Sending
{
    List<EmailDetails> mailSend = new();
    public Sending(List<EmailDetails> mailList)
    {
        mailSend = mailList;
    }
    public void Send()
    {

        Console.Clear();

        int id = 0;
        bool flag = true;

        Console.WriteLine("Here is your email list.");
        Viewing view = new(mailSend);
        view.View();

        Console.WriteLine("Please enter the ID for which you want to send email: ");
        while (flag)
        {
            try
            {
                id = int.Parse(Console.ReadLine());
                bool idFlag = true;
                while (idFlag)
                {
                    foreach (var img in mailSend)
                    {
                        if (id == img.Email_Id)
                        {
                            idFlag = false;
                        }
                    }
                    if (idFlag)
                    {
                        Console.WriteLine("Id not found!\nTry again");
                        id = int.Parse(Console.ReadLine());
                    }

                }
                flag = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input! \nPlease try again!");
            }
        }

        EmailDetails emailDetails = mailSend.Find(e => e.Email_Id == id);

        string to = emailDetails.Email; //To address    
        string from = "abhijeetb.aspirefox@gmail.com"; //From address
        
        MailMessage message = new MailMessage(from, to);

        Console.WriteLine("Please enter the subject of the email:");
        message.Subject = Console.ReadLine();

        Console.WriteLine("Please enter the body of the email(Press (CTRL + Z and enter) for ending the body part): ");
        var mailbody = Console.In.ReadToEnd();

        message.Body = mailbody;
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;
        message.SubjectEncoding = Encoding.UTF8;

        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp

        NetworkCredential basicCredential1 = new
        NetworkCredential("yourgmail@gmail.com", "Your_Credential_Password");

        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = basicCredential1;
        client.Send(message);

        Console.WriteLine("Email sent. \nThank you!");
        Console.WriteLine("Press enter to jump for main menu!");
        Console.ReadLine();
        Console.Clear();

    }
}