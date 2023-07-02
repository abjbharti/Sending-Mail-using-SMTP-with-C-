using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml.Linq;
using AbhijeetCSharpTest;


class Program
{
    public static void Main()
    {
        List<EmailDetails> emailDetails = new List<EmailDetails>();

        var client = new HttpClient();
        
        bool flag = true;
        
        Console.WriteLine("We are trying to send email.");

        //while loop starts
        while (flag)
        {
            Console.WriteLine("Please select your option: ");
            Console.WriteLine("1. Add email");
            Console.WriteLine("2. Edit email");
            Console.WriteLine("3. Delete email");
            Console.WriteLine("4. View email list");
            Console.WriteLine("5. Send the email with selecting Email_Id(ID)");
            Console.WriteLine("6. Broadcast Message");
            Console.WriteLine("7. For exit");

            Console.WriteLine("Please enter your selection: ");

            //Try to catch exception for invalid selection
            try
            {
                //Input for selection
                int selection;
                while (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: Please Provide valid id");
                }
                //Other method
                /*int selection = 0;
                selection = int.Parse(Console.ReadLine());*/
                
                switch (selection)
                {
                    //Add block
                    case 1:
                        Console.Clear();
                        Addition ad = new();
                        emailDetails.Add(ad.Adding());
                        Console.WriteLine("Email added successfully!");
                        break;

                    //Edit block
                    case 2:
                        Console.Clear();
                        Edition ed = new(emailDetails);
                        emailDetails.Add(ed.Edit());
                        break;

                    //Delete block
                    case 3:
                        Console.Clear();
                        Deletion dl = new(emailDetails);
                        dl.Delete();
                        break;

                    //View block
                    case 4:
                        Console.Clear();
                        Viewing vw = new(emailDetails);
                        vw.View();
                        break;

                    //Send block
                    case 5:
                        Console.Clear();
                        Sending sd = new(emailDetails);
                        sd.Send();
                        break;

                    //Broadcasting block
                    case 6:
                        Console.Clear();
                        Broadcasting brd = new(emailDetails);
                        brd.Broadcast();
                        break;

                    //Exit block
                    case 7:
                        Console.Clear();
                        flag = false;
                        Console.WriteLine("We are exiting \nThank you!");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Your selection is out of range. \nPlease select the integer between 1 to 7.");
                        break;

                }
                Console.WriteLine();

            }
            catch (Exception)
            {
                Console.WriteLine("Invalid selection! \nPlease try again!");
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        //while loop ends
        //You can remove try-catch block here as it is not used anywhere.
    }
}