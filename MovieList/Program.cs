using System;
using System.Collections.Generic;

namespace MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();
            PopulateList(movieList);
            int selection = 0;
            bool validInput = false;
            string search = "";
            string input = "";
            string message = "";
            bool exitCondition = false;
            while (!exitCondition)
            {
                while (!validInput)
                {
                    message = "Which movie category would you like to view?\n1. Action\n2. Animated\n3. Horror\n4. Scifi";
                    input = PromptUser(message);
                    try
                    {
                        selection = int.Parse(input);
                        if (selection == 1)
                        {
                            search = "Action";
                        }
                        else if (selection == 2)
                        {
                            search = "Animated";
                        }
                        else if (selection == 3)
                        {
                            search = "Horror";
                        }
                        else if (selection == 4)
                        {
                            search = "Scifi";
                        }
                        else
                        {
                            throw new Exception("Input out of range.");
                        }
                        validInput = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Invalid entry. Please make your selection with a number.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                for (int i = 0; i < movieList.Count; i++)
                {
                    if (search == movieList[i].Category)
                    {
                        Console.WriteLine(movieList[i].Title);
                    }
                }

                validInput = false;
                message = "Would you like to search a different category? y/n";
                while (!validInput)
                {
                    input = PromptUser(message).Trim().ToLower();
                    if (input == "y" || input == "n")
                    {
                        validInput = true;
                        if(input == "n")
                        {
                            exitCondition = true;
                        }
                    }
                    else
                    {
                        validInput = false;
                    }
                }
            }
            Console.WriteLine("Thank you for using the movie list program.");
        }

        public static string PromptUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().Trim();
        }

        public static void PopulateList(List<Movie> movies)
        {
            movies.Add(new Movie("Avatar", "Scifi"));
            movies.Add(new Movie("Baby Driver", "Action"));
            movies.Add(new Movie("Coco", "Animated"));
            movies.Add(new Movie("Die Hard", "Action"));
            movies.Add(new Movie("Ghost in the Shell", "Animated"));
            movies.Add(new Movie("It", "Horror"));
            movies.Add(new Movie("John Wick", "Action"));
            movies.Add(new Movie("Mad Max: Fury Road", "Action"));
            movies.Add(new Movie("Moana", "Animated"));
            movies.Add(new Movie("Revenge of the Sith", "Scifi"));
            movies.Add(new Movie("The Shining", "Horror"));
        }
    }
}
