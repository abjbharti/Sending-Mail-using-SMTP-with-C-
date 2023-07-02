using System.Xml.Linq;


namespace AbhijeetCSharpTest
{
    public class Addition
    {
        public EmailDetails Adding()
        {
            Console.Clear();
            Validation val = new();

            //For ID
            Console.Write("Please enter your ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine();
                Console.WriteLine("Error: Please Provide valid id");
            }

            //Other method
            /*int i = 0;
            bool flag = true;
            while (flag)
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                    flag = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input! \nPlease try again!");
                }
            }*/

            //For name
            Console.Write("Please enter your name: ");
            var name = Console.ReadLine();
            bool nameCheck = val.isValidName(name);
            while (nameCheck != true)
            {
                Console.Write("Enter correct name: ");
                name = Console.ReadLine();
                nameCheck = val.isValidName(name);
            }

            //For email
            Console.Write("Please enter your email id: ");
            var email = Console.ReadLine();
            bool emailCheck = val.isValidEmail(email);
            while (emailCheck != true)
            {
                Console.Write("Enter correct email: ");
                email = Console.ReadLine();
                emailCheck = val.isValidEmail(email);
            }

            EmailDetails mailAdd = new(id, name, email);
            return mailAdd;
        }
    }
}