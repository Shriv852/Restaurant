using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Restaurant
{
    class Program
    {
        public static List<int> orderNum = new List<int>();
        public static void Main(string[] args)
        {
            bool loop = true;
            while (loop == true)
            {
                int runLoopNum = Run();

                if (runLoopNum == 1)
                {
                    Console.WriteLine("Check in: ");

                    Console.WriteLine("Name: ");
                    string name1 = Console.ReadLine();

                    Console.WriteLine("Address: ");
                    string address1 = Console.ReadLine();

                    Console.WriteLine("Phone Number: ");
                    string phoneNum = Console.ReadLine();

                    Console.WriteLine("How many people are in your party today");
                    int partyNum = Convert.ToInt32(Console.ReadLine());

                    Customers customers1 = new Customers(name1, address1, phoneNum);

                    Console.WriteLine("Welcome " + name1 + "! Please follow me to your table");
                    Thread.Sleep(2000);
                }
                if (runLoopNum == 2)
                {
                    Console.WriteLine("--------------Menu---------------");
                    Menu();
                    Console.WriteLine("---------------------------------");
                }
                if (runLoopNum == 3)
                {
                    Console.WriteLine("Enter 1 to Order OR Enter 2 to Finish Ordering");
                    int order = Convert.ToInt32(Console.ReadLine());
                    do
                    {
                        Console.WriteLine("What would you like to order?");
                        orderNum.Add(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Good Choice!");

                        Console.WriteLine("1: Order \n2: End Order");
                        order = Convert.ToInt32(Console.ReadLine());
                    } while (order == 1);

                    Console.WriteLine("Preparing Food.....");
                    Thread.Sleep(3000);
                    Console.WriteLine("Eating....");
                    Thread.Sleep(5000);
                }
                if (runLoopNum == 4)
                {
                    Reciept(orderNum, new double[] { 8.99, 10.99, 14.00, 19.99, 8.99, 10.99, 6.00, 10.50 }, 0.00);
                }
                if (runLoopNum == 5)
                {
                    Console.WriteLine("How much would you like to tip?");
                    double tip = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Tip Added!");
                    Reciept(orderNum, new double[] { 8.99, 10.99, 14.00, 19.99, 8.99, 10.99, 6.00, 10.50 }, tip);
                }


                if (runLoopNum == 6)
                {
                    loop = false;
                }
            }
        } //End Main

        public static int Run()
        {
            Console.WriteLine("-------Main Menu---------");
            Console.WriteLine("Press 1 to Check In");
            Console.WriteLine("Press 2 to Ask for Menu");
            Console.WriteLine("Press 3 to Order");
            Console.WriteLine("Press 4 to Ask for Reciept");
            Console.WriteLine("Press 5 to Add Tip");
            Console.WriteLine("Press 6 to Exit");
            Console.WriteLine("--------------------------");


            return Convert.ToInt32(Console.ReadLine());
        } //End Run Method

        public static void Menu()
        {
            double[] itemPrices = new double[] { 8.99, 10.99, 14.00, 19.99, 8.99, 10.99, 6.00, 10.50 };

            string[,] menuItems = new string[,]
            {
                {"0: Bread Basket", itemPrices[0].ToString("C", CultureInfo.CurrentCulture)},
                {"1: Garlic and Cheese Bread", itemPrices[1].ToString("C", CultureInfo.CurrentCulture)},
                {"2: Salt and Pepper Calamari", itemPrices[2].ToString("C", CultureInfo.CurrentCulture)},
                {"3: Tasmanian Salmon",  itemPrices[3].ToString("C", CultureInfo.CurrentCulture) },
                {"4: Creme Burulee",  itemPrices[4].ToString("C", CultureInfo.CurrentCulture) },
                {"5: Hazelnut Cheesecake",  itemPrices[5].ToString("C", CultureInfo.CurrentCulture) },
                {"6: Garden Salad",  itemPrices[6].ToString("C", CultureInfo.CurrentCulture) },
                {"7: Caesar Salad",  itemPrices[7].ToString("C", CultureInfo.CurrentCulture) }
            };

            for (int i = 0; i < menuItems.Length / 2; i++)
            {
                string item1 = menuItems[i, 0];
                string item2 = menuItems[i, 1];
                Console.WriteLine("{0}     {1}", item1, item2);
            }
        } //End Menu Method

        public static void Reciept(List<int> orderNum1, double[] itemPrices, double tip)
        {
            double total = 0.0;
            for (int i = 0; i < orderNum1.Count; i++)
            {
                total += itemPrices[i] + tip;
            }
            Console.WriteLine("Total: " + total.ToString("C", CultureInfo.CurrentCulture));
        }
    }
}
