namespace PortfolioOfEvidence
{
    class RecipeApp
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe(); //Creating an instance of the Recipe Class.
            bool exit = false;

            while (!exit) //While the bool value is still false the program should continue running.
            {
                Console.WriteLine("Select an option: ");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Scale recipe");
                Console.WriteLine("3. Display Recipe");
                Console.WriteLine("4. Reset quantity");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice) //A swith is created for the user to choose between the different options in the program.
                {
                    case 1:
                        Console.Clear();
                        recipe.EnterRecipeDetails(); //For every case, a method is called from the Recipe Class.
                        break;
                    case 2:
                        Console.Clear();
                        recipe.SclaeRecipe();
                        break;
                    case 3:
                        Console.Clear();
                        recipe.DisplayRecipeDetails();
                        break;
                    case 4:
                        Console.Clear();
                        recipe.ResetQuatity();
                        break;
                    case 5:
                        Console.Clear();
                        recipe.ClearData();
                        break;
                    case 6:
                        exit = true; //If case 6 is chosen then the bool value is made true and the program closes.
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6."); //If the users choice is invalid they will have to put a valid choice to run a task on the program.
                        break;

                }
            }
        }
    }

    class Recipe
    {
        private string[] ingredientName; //Arrays created.
        private string[] measurementUnit;
        private double[] quantity;
        private string[] steps;
        private int recipeCount = 0; //Recipe counter variable is created to keep track of the amount of recpies on the system.

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the total number of ingredients in the recipe: ");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredientName = new string[numIngredients]; //The size of the following arrays are dependant on the number of ingredients a user enters.
            measurementUnit = new string[numIngredients];
            quantity = new double[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("Enter the name of ingredient " + (i + 1) + ": ");
                ingredientName[i] = Console.ReadLine();

                Console.WriteLine("Enter the unit of measurement for the ingredient: ");
                measurementUnit[i] = Console.ReadLine();

                Console.WriteLine("Enter the quantity of the ingredient. (Corresponding to the unit of measurement): ");
                quantity[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the total number of steps for the recipe: ");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps]; // The size of the following array is dependant on how many steps the recipe consists of.

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Enter details for STEP " + (i + 1) + ": ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Recipe details have been stored successfully.");
            Console.WriteLine("---------------------------------------------");

            recipeCount++; //Once all the steps to entering a recipe are completed the recipe count variable gets incremented.
        }

        public void SclaeRecipe()
        {
            Console.WriteLine("Enter the factor you would like to scale the recipe by: ");
            double factor = double.Parse(Console.ReadLine());

            if (recipeCount > 0) //If there are no recipe's on the system then the task will not run
            {
                for (int i = 0; i < quantity.Length; i++)
                {
                    quantity[i] *= factor; // The quantity is increased or decreased depending on the factor that a user enters.
                }

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("The recipe has been scaled by " + factor + ".");
                Console.WriteLine("---------------------------------------------");
            }
            else
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("There are no recipes's stored in the system.");
                Console.WriteLine("--------------------------------------------");
            }
        }

        public void DisplayRecipeDetails()
        {

            if (recipeCount > 0) //If there are no recipe's on the system then the task will not run
            {
                for (int i = 0; i < recipeCount; i++)
                {

                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("INGREDIENTS: ");

                    for (int j = 0; j < ingredientName.Length; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Use of advanced features. Changes colour of the console text.
                        Console.WriteLine(quantity[j] + " " + measurementUnit[j] + " of " + ingredientName[j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine();
                    Console.WriteLine("RECIPE: ");

                    for (int j = 0; j < steps.Length; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine((j + 1) + ". " + steps[j]);
                        Console.ForegroundColor = ConsoleColor.White; //Reverts to original text colour for the rest of the program.
                    }

                    Console.WriteLine("---------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("There are no recipes's stored in the system.");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public void ResetQuatity()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Quantity has been reset to initial value.");
            Console.WriteLine("---------------------------------------------");
        }

        public void ClearData()
        {
            string confirm = "No";

            Console.WriteLine("Are you sure you would like to clear all the data? ");
            Console.WriteLine("Yes or No");
            confirm = Console.ReadLine(); //User is asked to confirm the deletoion of the recipes on the system
            if (confirm == "Yes")
            {
                ingredientName = null;
                quantity = null;
                measurementUnit = null;
                steps = null;
                recipeCount = 0;

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("All the recipe's have been removed from the system.");
                Console.WriteLine("---------------------------------------------------");
            }
            else
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("All the recipe's will remain on the system.");
                Console.WriteLine("---------------------------------------------");
            }
        }
    }
}
