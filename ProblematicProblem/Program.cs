using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static List<string> activities = new List<string>() { "Movies",
                                                              "Paintball",
                                                              "Bowling",
                                                              "Lazer Tag",
                                                              "LAN Party",
                                                              "Hiking",
                                                              "Axe Throwing",
                                                              "Wine Tasting" };
        static void Main(string[] args)
        {
            bool cont = true;
            bool valid;
            string tryAgain = "Invalid input, try again: ";
            Random rng = new Random();

            //int randomValue = rng.Next(activities.Count - 1);
            //Console.WriteLine(activities[randomValue]);

            //Testing what generates a CS0841

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            do
            {

                if (Console.ReadLine().ToLower() == "yes")
                {
                    cont = true;
                    valid = true;
                }
                else if (Console.ReadLine().ToLower() == "no")
                {
                    cont = false;
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.Write(tryAgain);
                }
            } while (!valid);

            //The program is proceeding regardless of choice, fix this

            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge;
            do
            {
                int.TryParse(Console.ReadLine(), out int ageInput);
                if (ageInput > 0)
                {
                    userAge = ageInput;
                    valid = true;
                }
                else
                {
                    userAge = 0;
                    valid = false;
                    Console.Write(tryAgain);
                }
            } while (!valid);
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? yes/no: ");
            bool seeList;
            do
            {

                if (Console.ReadLine().ToLower() == "yes")
                {
                    seeList = true;
                    valid = true;
                }
                else if (Console.ReadLine().ToLower() == "no")
                {
                    seeList = false;
                    valid = true;
                }
                else
                {
                    seeList = false;
                    valid = false;
                    Console.Write(tryAgain);
                }
            } while (!valid);
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
            }
            Console.WriteLine();
            Console.Write("Would you like to add any activities before we generate one? yes/no: ");
            bool addToList;
            do
            {

                if (Console.ReadLine().ToLower() == "yes")
                {
                    addToList = true;
                    valid = true;
                }
                else if (Console.ReadLine().ToLower() == "no")
                {
                    addToList = false;
                    valid = true;
                }
                else
                {
                    addToList = false;
                    Console.Write(tryAgain);
                }
            } while (!valid);
            Console.WriteLine();
            while (addToList)
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();
                activities.Add(userAddition);
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no: ");
                do
                {

                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        addToList = true;
                        valid = true;
                    }
                    else if (Console.ReadLine().ToLower() == "no")
                    {
                        addToList = false;
                        valid = true;
                    }
                    else
                    {
                        addToList = false;
                        Console.Write(tryAgain);
                    }
                } while (!valid);
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count - 1);
                string randomActivity = activities[randomNumber];
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
                do
                {

                    if (Console.ReadLine().ToLower() == "keep")
                    {
                        cont = false;
                        valid = true;
                    }
                    else if (Console.ReadLine().ToLower() == "redo")
                    {
                        cont = true;
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        Console.Write(tryAgain);
                    }
                } while (!valid);
            }
        }
    }
}