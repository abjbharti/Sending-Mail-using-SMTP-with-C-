using AbhijeetCSharpTest;

public class Viewing
{

    List<EmailDetails> mailShow = new();

    public Viewing(List<EmailDetails> mailList)
    {
        mailShow = mailList;
    }

    public void View()
    {
        Console.Clear();

        Console.WriteLine("Here is your full email table");

        Console.WriteLine("ID\t\t Name\t\t\t Email");


        foreach (var em in mailShow)
        {

            Console.WriteLine($" {em.Email_Id}\t\t {em.Name} \t\t\t {em.Email}");
        }

        Console.WriteLine();

    }
}