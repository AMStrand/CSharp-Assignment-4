// Alyssa Strand
// This assignment builds off the Droid Collection assignment.  It adds functionality to sort the 
// droid collection in two ways.  Sorting by type uses a modified bucket sort of stacks and a queue.
// Sorting by total cost uses a merge sort based on the IComparable array of droids.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new droid collection and set the size of it to 100.
            DroidCollection droidCollection = new DroidCollection(100);

            //Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            // Load in 12 droids for easier testing:
            droidCollection.PreloadDroids();

            //Display the main greeting for the program
            userInterface.DisplayGreeting();

            //Display the main menu for the program
            userInterface.DisplayMainMenu();

            //Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            //While the choice is not equal to 5, continue to do work with the program
            while (choice != 5)
            {
                //Test which choice was made
                switch (choice)
                {
                    //Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;

                    //Choose to Print the droid
                    case 2:
                        userInterface.PrintDroidList();
                        break;
                    // Sort the droids by type:
                    case 3:
                        droidCollection.SortDroidsByType();

                            // Output confirmation to user:
                        Console.WriteLine();
                        Console.WriteLine("Droids have been sorted by type!");
                        Console.WriteLine();
                        break;
                    // Sort the droids by cost:
                    case 4:
                        droidCollection.SortDroidsByPrice();

                            // Output confirmation to user:
                        Console.WriteLine();
                        Console.WriteLine("Droids have been sorted by cost!");
                        Console.WriteLine();
                        break;
                }
                //Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }


        }
    }
}
