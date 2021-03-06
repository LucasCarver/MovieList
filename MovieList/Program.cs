﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();
            PopulateList(movieList);
            movieList = movieList.OrderBy(movie => movie.Title).ToList();
            int selection = 0;
            bool validInput;
            string search = "";
            string input = "";
            string message = "";
            bool exitCondition = false;
            while (!exitCondition)
            {
                validInput = false;
                while (!validInput)
                {
                    message = "Which movie category would you like to view?\n 1. Action\n 2. Animated\n 3. Horror\n 4. Scifi";
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
                    try
                    {
                        input = PromptUser(message).Trim().ToLower();
                        if (input != "y" && input != "n")
                        {
                            throw new Exception("Invalid input. Please try again.");
                        }
                        else
                        {
                            if (input == "n")
                            {
                                exitCondition = true;
                            }
                            validInput = true;
                        }


                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    //input = PromptUser(message).Trim().ToLower();
                    //if (input == "y" || input == "n")
                    //{
                    //    validInput = true;
                    //    if(input == "n")
                    //    {
                    //        exitCondition = true;
                    //    }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Invalid input. Please try again.");
                    //    validInput = false;
                    //}
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
            movies.Add(new Movie("Revenge of the Sith", "Scifi"));
            movies.Add(new Movie("John Wick", "Action"));
            movies.Add(new Movie("Mad Max: Fury Road", "Action"));
            movies.Add(new Movie("Moana", "Animated"));
            movies.Add(new Movie("Coco", "Animated"));
            movies.Add(new Movie("Die Hard", "Action"));
            movies.Add(new Movie("Ghost in the Shell", "Animated"));
            movies.Add(new Movie("Baby Driver", "Action"));
            movies.Add(new Movie("It", "Horror"));
            movies.Add(new Movie("The Shining", "Horror"));
            movies.Add(new Movie("Avatar", "Scifi"));
        }

        public static void SortList(List<Movie> movies)
        {

        }
    }
}
