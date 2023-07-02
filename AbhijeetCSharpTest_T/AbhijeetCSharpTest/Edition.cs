public class Edition
{

    List<EmailDetails> mailEdit = new();
    public Edition(List<EmailDetails> mailList)
    {
        mailEdit = mailList;
    }

    public EmailDetails Edit()
    {
        Console.WriteLine("Here is your email list.");
        Viewing view = new(mailEdit);
        view.View();

        Console.WriteLine("Enter the id you want to edit: ");
        int id = 0;
        bool flag = true;

        Validation val = new();

        while (flag)
        {
            try
            {
                id = int.Parse(Console.ReadLine());
                bool idFlag = true;
                while (idFlag)
                {
                    foreach (var img in mailEdit)
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

        //For update ID
        Console.Write("Please enter updated ID: ");

        int updateID;
        while (!int.TryParse(Console.ReadLine(), out updateID))
        {
            Console.WriteLine();
            Console.WriteLine("Error: Please Provide valid id");
        }
        
        //Other method
        /*int updateID = 0;
        bool updateFlag = true;
        while (updateFlag)
        {
            try
            {
                updateID = int.Parse(Console.ReadLine());
                updateFlag = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid! \nPlease try again!");
            }
        }*/

        //For updated name
        Console.Write("Please enter updated name: ");
        var name = Console.ReadLine();
        bool nameCheck = val.isValidName(name);
        while (nameCheck != true)
        {
            Console.Write("Enter correct name: ");
            name = Console.ReadLine();
            nameCheck = val.isValidName(name);
        }


        //For updated email
        Console.Write("Please enter updated email id: ");
        var email = Console.ReadLine();
        bool emailCheck = val.isValidEmail(email);
        while (emailCheck != true)
        {
            Console.Write("Enter correct email: ");
            email = Console.ReadLine();
            emailCheck = val.isValidEmail(email);
        }

        mailEdit.RemoveAll(e => e.Email_Id == id);

        EmailDetails editEmail = new(updateID, name, email);

        return editEmail;

    }
}