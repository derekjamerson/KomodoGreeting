using KomodoGreeting.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreeting.Console
{
    public class ProgramUI
    {
        CustomerRepo repo = new CustomerRepo();
        public void Run()
        {
            while (true)
            {
                PrintMainMenu();
            }
        }
        public void PrintMainMenu()
        {
            System.Console.CursorVisible = false;
            PrintTitle();
            string aNew = " Add new Customer";
            int selection = -1;
            bool loop = true;
            List<Customer> _list = repo.GetList();
            string h1 = "First Name";
            string h2 = "Last Name";
            string h3 = "Type";
            string h4 = "Email";
            System.Console.Write(String.Format("|{0,-12}|{1,-12}|{2,-12}|", h1, h2, h3) + h4 + "\n\n");
            while (loop)
            {
                if(selection == -1)
                {
                    System.Console.BackgroundColor = ConsoleColor.White;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }
                System.Console.Write(aNew + new string(' ', System.Console.WindowWidth - aNew.Length) + "\n\n");
                System.Console.ResetColor();
                for(int i = 0; i < _list.Count; i++)
                {
                    Customer c = repo.GetList()[i];
                    if(selection == i)
                    {
                        System.Console.BackgroundColor = ConsoleColor.White;
                        System.Console.ForegroundColor = ConsoleColor.Black;
                    }
                    System.Console.Write(String.Format("|{0,-12}|{1,-12}|{2,-12}|", c.FirstName, c.LastName, c.Type) + PrintEmail(c.Type) + "\n\n");
                    System.Console.ResetColor();
                }
                switch (System.Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if(selection > -1)
                        {
                            selection--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(selection < _list.Count - 1)
                        {
                            selection++;
                        }
                        break;
                    case ConsoleKey.Escape:
                        System.Environment.Exit(0);
                        break;
                    case ConsoleKey.Enter:
                        DoMainMenu(selection);
                        loop = false;
                        break;
                }
                System.Console.ReadLine();
                
            }
        }
        public void PrintTitle()
        {
            System.Console.Clear();
            string title = "Komodo Greeting Application";
            System.Console.WriteLine(string.Format("{0," + ((System.Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
            System.Console.WriteLine("\n");
        }
        public string PrintEmail(Customer.CustomerType type)
        {
            switch (type)
            {
                case Customer.CustomerType.Past:
                    return "It's been a long time since we've heard from you, we want you back.";
                case Customer.CustomerType.Current:
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                case Customer.CustomerType.Potential:
                    return "We currently have the lowest rates on Helicopter Insurance!";
                default:
                    return new string(' ', System.Console.WindowWidth);
            }
        }
        public void DoMainMenu(int selection)
        {
            if(selection != -1)
            {

            }
        }
    }
}
