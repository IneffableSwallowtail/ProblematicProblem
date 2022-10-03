using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
            bool generate = true;
            bool cont = true;
            bool valid;
            string tryAgain = "Invalid input, try again: ";
            Random rng = new Random();
            string userName;

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            do
            {
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "yes")
                {
                    generate = true;
                    valid = true;
                }
                else if (userInput == "no")
                {
                    generate = false;
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.Write(tryAgain);
                }
            } while (!valid);

            if (generate)
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                bool validUsername;
                do
                {
                    userName = Console.ReadLine();
                    if (string.IsNullOrEmpty(userName))
                    {
                        validUsername = false;
                        Console.Write(tryAgain);
                    }
                    else validUsername = true;
                } while (!validUsername);

                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge;
                do
                {
                    int.TryParse(Console.ReadLine(), out userAge);
                    if (userAge > 0)
                    {
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                        Console.Write(tryAgain);
                    }
                } while (!valid);

                while (cont)
                {
                    Console.WriteLine();
                    Console.Write("Would you like to see the current list of activities? yes/no: ");
                    bool seeList;
                    do
                    {
                        string userInput = Console.ReadLine().ToLower();
                        if (userInput == "yes")
                        {
                            seeList = true;
                            valid = true;
                        }
                        else if (userInput == "no")
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
                        string userInput = Console.ReadLine().ToLower();
                        if (userInput == "yes")
                        {
                            addToList = true;
                            valid = true;
                        }
                        else if (userInput == "no")
                        {
                            addToList = false;
                            valid = true;
                        }
                        else
                        {
                            addToList = false;
                            valid = false;
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
                            string userInput = Console.ReadLine().ToLower();
                            if (userInput == "yes")
                            {
                                addToList = true;
                                valid = true;
                            }
                            else if (userInput == "no")
                            {
                                addToList = false;
                                valid = true;
                            }
                            else
                            {
                                addToList = false;
                                valid = false;
                                Console.Write(tryAgain);
                            }
                        } while (!valid);
                    }

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
                    
                    
                    //consider adding code to take out the unwanted activity
                    Console.WriteLine();
                    do
                    {
                        string userInput = Console.ReadLine().ToLower();
                        if (userInput == "keep")
                        {
                            cont = false;
                            valid = true;
                        }
                        else if (userInput == "redo")
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
}