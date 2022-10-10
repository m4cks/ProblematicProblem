using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            cont = BetterParse(Console.ReadLine());
            Console.WriteLine();
            if (cont)
            {
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                bool seeList = BetterParse(Console.ReadLine());
                if (seeList)
                {
                    WriteActivities(activities);
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    bool addToList = BetterParse(Console.ReadLine());
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        WriteActivities(activities);
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        addToList = BetterParse(Console.ReadLine());
                    }
                }
                Random rng = new Random();
                string randomActivity = activities[rng.Next(activities.Count)];
                while (cont && activities.Count > 0)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(100);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(100);
                    }
                    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    cont = BetterParse(Console.ReadLine());
                    if (cont)
                    {
                        activities.Remove(randomActivity);
                    }
                }
                if (!cont && activities.Count > 0)
                {
                    Console.WriteLine($"Have a good time doing {randomActivity}!");
                }
                else
                {
                    Console.WriteLine("You didn't like any of the activities? :(");
                }
            } else
            {
                Console.WriteLine("Aw :/");
            }
        }


        public static bool BetterParse(string input)
        {
            switch(input.ToUpper())
            {
                case "SURE":
                    return true;
                case "YES":
                    return true;
                case "TRUE":
                    return true;
                case "HELL YEAH":
                    return true;
                case "REDO":
                    return true;
            }
            return false;
        }

        public static void WriteActivities(List<string> activities)
        {
            foreach (string activity in activities)
            {
                Console.Write($"{activity}  ");
                Thread.Sleep(250);
            }
        }
    }
}