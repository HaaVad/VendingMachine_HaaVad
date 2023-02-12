using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TheVendingMachine
{
    public class VendingMachine
    {
        private static int money;

        public Confectionery? Confectionery;

        public List<Confectionery> inventory = new()
        {
            new Confectionery("snickers",5, 20),
            new Confectionery("kitkat",3, 15),
            new Confectionery("milkyway",3, 15),
            new Confectionery("We dont have that",0,99)
        };
        public void StartVendingMachine()
        {
            while (true)
            {
                WelcomeMessage();
                string input = Console.ReadLine()!;
                if (input.StartsWith("insert"))
                { Insert(input); }
                else if (input.Equals("recall"))
                { Recall(); }
                else if (input.StartsWith("sms order"))
                { NewSMSOrder(input); }
                else if (input.StartsWith("order"))
                { NewOrder(input); }
                else { Console.WriteLine("Does not compute"); }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        public Confectionery PickChocloate(string conf) 
        {
            if (conf == "snickers")
                return inventory[0];
            else if (conf == "kitkat")
                return inventory[1];
            else if (conf == "milkyway")
                return inventory[2];
            else
                return inventory[3];
        }
        public void NewSMSOrder(string input)
        {
            string conf = input.Split(' ')[2];
            Confectionery choice = PickChocloate(conf);
            if (choice.Nr > 0)
            {
                Console.WriteLine($"Giving {choice.Name} out");
                choice.Nr--;
            }
        }
        public void NewOrder(string input)
        {
            string conf = input.Split(' ')[1];
            Confectionery choice = PickChocloate(conf);
            if(choice == inventory[2])
            { Console.WriteLine(choice.Name); }
            else if (choice.Price <= money && choice.Nr > 0)
            {
                Console.WriteLine($"Giving {choice.Name} out");
                money -= choice.Price;
                Console.WriteLine("Giving " + money + " out in change");
                money = 0;
                choice.Nr--;
            }
            else if (choice.Nr == 0)
            {
                Console.WriteLine($"No {choice.Name} left");
            }
            else if (choice.Price > money)
            {
                Console.WriteLine($"Need " + (choice.Price - money) + " more");
            }
        }
        public static void Insert(string input)
        {
            money += int.Parse(input.Split(' ')[1]);
            Console.WriteLine("Adding " + int.Parse(input.Split(' ')[1]) + " to credit");
        }
        public static void Recall()
        {
            Console.WriteLine("Returning " + money + " to customer");
            money = 0;
        }
        public static void WelcomeMessage()
        {
            Console.WriteLine("\n\nAvailable commands:");
            Console.WriteLine("insert (money) - Money put into money slot");
            Console.WriteLine("order (snickers, kitkat, milkyway) - Order from machines buttons");
            Console.WriteLine("sms order (snickers, kitkat, milkyway) - Order sent by sms");
            Console.WriteLine("recall - gives money back");
            Console.WriteLine("-------");
            Console.WriteLine("Inserted money: " + money);
            Console.WriteLine("-------\n\n");
        }
    }
}




//Confectionery snickers = new("snickers", 5, 20);
//Confectionery kitkat = new("kitkat", 3, 15);
//Confectionery milkyway = new("milkyway", 3, 15);
//Confectionery fake = new("We dont have that", 0, 0);

//public void UpdateInventory()
//{
//    inventory.Add(snickers); 
//    inventory.Add(kitkat); 
//    inventory.Add(milkyway);
//}
//public Dictionary<string, int> cocoInventory = new()
//{
//    {"snickers", 5 },
//    {"kitkat", 3 },
//    {"milkyway", 3 },
//};

//public void Order(string input) 
//{
//    // split string on space
//    string conf = input.Split(' ')[1];
//    //Find out witch kind
//    switch (conf)
//    {
//        case "snickers":
//            var snickers = inventory[0];
//            if (snickers.Name == conf && money > 19 && snickers.Nr > 0)
//            {
//                Console.WriteLine("Giving snickers out");
//                money -= 20;
//                Console.WriteLine("Giving " + money + " out in change");
//                money = 0;
//                snickers.Nr--;
//            }
//            else if (snickers.Name == conf && snickers.Nr == 0)
//            {
//                Console.WriteLine("No snickers left");
//            }
//            else if (snickers.Name == conf)
//            {
//                Console.WriteLine("Need " + (20 - money) + " more");
//            }

//            break;
//        case "milkyway":
//            var milkyway = inventory[2];
//            if (milkyway.Name == conf && money > 14 && milkyway.Nr >= 0)
//            {
//                Console.WriteLine("Giving milkyway out");
//                money -= 15;
//                Console.WriteLine("Giving " + money + " out in change");
//                money = 0;
//                milkyway.Nr--;
//            }
//            else if (milkyway.Name == conf && milkyway.Nr == 0)
//            {
//                Console.WriteLine("No milkyway left");
//            }
//            else if (milkyway.Name == conf)
//            {
//                Console.WriteLine("Need " + (15 - money) + " more");
//            }

//            break;
//        case "kitkat":
//            var kitkat = inventory[1];
//            if (kitkat.Name == conf && money > 14 && kitkat.Nr > 0)
//            {
//                Console.WriteLine("Giving kitkat out");
//                money -= 15;
//                Console.WriteLine("Giving " + money + " out in change");
//                money = 0;
//                kitkat.Nr--;
//            }
//            else if (kitkat.Name == conf && kitkat.Nr == 0)
//            {
//                Console.WriteLine("No kitkat left");
//            }
//            else if (kitkat.Name == conf)
//            {
//                Console.WriteLine("Need " + (15 - money) + " more");
//            }
//            break;
//        default:
//            Console.WriteLine("No such confectionery");
//            break;
//    }
//}
//public void SMSOrder(string input) 
//{
//    string conf = input.Split(' ')[2];
//    //Find out witch kind
//    switch (conf)
//    {
//        case "snickers":
//            if (inventory[0].Nr > 0)
//            {
//                Console.WriteLine("Giving snickers out");
//                inventory[0].Nr--;
//            }
//            break;
//        case "kitkat":
//            if (inventory[1].Nr > 0)
//            {
//                Console.WriteLine("Giving kitkat out");
//                inventory[1].Nr--;
//            }
//            break;
//        case "milkyway":
//            if (inventory[2].Nr > 0)
//            {
//                Console.WriteLine("Giving milkyway out");
//                inventory[2].Nr--;
//            }
//            break;
//    }


//}