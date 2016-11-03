using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private Droid[] droidCollection;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;
        // Private variable to hold the auxiliary droid collection for merge sort:
        private Droid[] auxDroidCollection = new Droid[100];

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new Droid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }
        
            // List of droids to pre-load for easier testing:
        public void PreloadDroids()
        {
            Add("Carbonite", "Protocol", "Bronze", 3);
            Add("Vanadium", "Utility", "Silver", true, true, false);
            Add("Quadranium", "Astromech", "Gold", true, true, true, true, 5);
            Add("Carbonite", "Janitorial", "Gold", true, false, true, false, true);
            Add("Vanadium", "Protocol", "Bronze", 1);
            Add("Vanadium", "Astromech", "Silver", true, false, true, false, 2);
            Add("Quadranium", "Utility", "Gold", true, true, true);
            Add("Carbonite", "Astromech", "Bronze", true, false, false, false, 1);
            Add("Vanadium", "Janitorial", "Silver", false, false, true, false, false);
            Add("Quadranium", "Protocol", "Silver", 4);
            Add("Carbonite", "Utility", "Bronze", false, false, false);
            Add("Quadranium", "Janitorial", "Gold", true, true, true, true, true);
        }

            // Public method to sort the droids by type:
        public void SortDroidsByType()
        {
                // Instantiate the GenericStack for each type of droid:
            GenericStack<Droid> protocolStack = new GenericStack<Droid>();
            GenericStack<Droid> utilityStack = new GenericStack<Droid>();
            GenericStack<Droid> janitorialStack = new GenericStack<Droid>();
            GenericStack<Droid> astromechStack = new GenericStack<Droid>();
                // Instantiate the GenericQueue to be used:
            GenericQueue<Droid> droidQueue = new GenericQueue<Droid>();

                // Loop through the droidCollection and sort the droids by type, putting into their stacks:
            for (int i = 0; i < lengthOfCollection; i++)
            {
                    // If the droid is of type ProtocolDroid, add to the protocolStack:
                if (droidCollection[i].GetType() == typeof(ProtocolDroid))
                {
                    protocolStack.AddToFront(droidCollection[i]);
                }
                    // If the droid is of type UtilityDroid, add to the utilityStack:
                else if (droidCollection[i].GetType() == typeof(UtilityDroid))
                {
                    utilityStack.AddToFront(droidCollection[i]);
                }
                    // If the droid is of type JanitorDroid, add to the janitorialStack:
                else if (droidCollection[i].GetType() == typeof(JanitorDroid))
                {
                    janitorialStack.AddToFront(droidCollection[i]);
                }
                    // Else, the droid is of type AstromechDroid, so add to the astromechStack:
                else
                {
                    astromechStack.AddToFront(droidCollection[i]);
                }
            }
            // Place the droids in the queue in the desired order (astromech, janitor, utility, protocol)
            // by removing the current droid from the appropriate stack and adding it to the back of the queue
            // until the size of the current stack is 0:
            while (astromechStack.Size > 0)
            {
                droidQueue.AddToBack(astromechStack.RemoveFromFront());
            }
            while (janitorialStack.Size > 0)
            {
                droidQueue.AddToBack(janitorialStack.RemoveFromFront());
            }
            while (utilityStack.Size > 0)
            {
                droidQueue.AddToBack(utilityStack.RemoveFromFront());
            }
            while (protocolStack.Size > 0)
            {
                droidQueue.AddToBack(protocolStack.RemoveFromFront());
            }

            // Replace the droids in droidCollection with the now sorted droid collection from the droidQueue:
            for (int i = 0; i < lengthOfCollection; i++)
            {
                droidCollection[i] = droidQueue.RemoveFromFront();
            }

        }

            // Public method to sort the droids by cost:
        public void SortDroidsByPrice()
        {
            SortDroids(droidCollection, 0, lengthOfCollection - 1);
        }

            // Private recursive method called by the SortDroidsByPrice method to break the droidCollection into 
            // smaller pieces and feed it to the MergeDroids method to sort it by parts:
        private void SortDroids(Droid[] arr, int low, int high)
        {
                // Done when the high is less than the low:
            if (high <= low)
            {
                return;
            }
            else
            {
                    // Find the current mid-point:
                int mid = low + ((high - low) / 2);
                    // Sort the sub-array that is the first half of the current array:
                SortDroids(arr, low, mid);
                    // Sort the sub-array that is the second half of the current array:
                SortDroids(arr, mid + 1, high);
                    // Merge the droids for the current array:
                MergeDroids(arr, low, mid, high);
            }
        }

            // Private methods to merge the droids of the current array into their proper order:
        private void MergeDroids(Droid[] arr, int low, int mid, int high)
        {
                // Declare variables to be used:
            int i = low;
            int j = mid + 1;

                // Copy the droidCollection to the auxiliary collection:
            for (int k = low; k <= high; k++)
            {
                auxDroidCollection[k] = arr[k];
            }

                // Loop through the droids and sort them by price:
            for (int k = low; k <= high; k++)
            {
                    // If the low point is higher than the mid, save the mid + 1 at the current point:
                if (i > mid)
                {
                    arr[k] = auxDroidCollection[j++];
                }
                    // If the mid + 1 is greater than the high point, save the current low at the current point:
                else if (j > high)
                {
                    arr[k] = auxDroidCollection[i++];
                }
                    // If the droid to the right has a lower total cost than the one to the left, move it left:
                else if (auxDroidCollection[j].CompareTo(auxDroidCollection[i]) < 0)
                {
                    arr[k] = auxDroidCollection[j++];
                }
                    // Otherwise, save the droid at the current low point to the current point:
                else
                {
                    arr[k] = auxDroidCollection[i++];
                }
            }
        }
    }
}
