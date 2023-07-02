public class Deletion
{
    List<EmailDetails> mailDelete = new();

    public Deletion(List<EmailDetails> mail1)
    {
        mailDelete = mail1;
    }

    public List<EmailDetails> Delete()
    {
        Console.Clear();

        if (mailDelete.Count == 0)
        {
            Console.WriteLine("\nThe list is already empty\n");
            Console.WriteLine("Press Enter to return to Main menu");
            Console.ReadLine();
            return mailDelete;
        }

        bool loopFlag = true;
        while (loopFlag)
        {
            Viewing print = new(mailDelete);
            print.View();

            Console.WriteLine("\nEnter the Email Id to delete.\n");
            int num = Convert.ToInt32(Console.ReadLine());

            bool idFlag = false;
            foreach (var item in mailDelete)
            {
                if (num == item.Email_Id)
                {
                    idFlag = true;
                    loopFlag = false;
                    mailDelete.RemoveAll(e => e.Email_Id == num);
                    Console.WriteLine("\nDeleted\n");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    break;
                }
            }

            if (idFlag == false)
            {
                Console.WriteLine("\nEmail Not Found!\n");
                Console.WriteLine("\nTry Again!!\n");
            }

        }
        return mailDelete;
    }
}