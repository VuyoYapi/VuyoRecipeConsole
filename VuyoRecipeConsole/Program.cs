using System;

namespace VuyoRecipeConsole
{
    //summary
    //Provides the entry and console menu for the recipe
    internal class Program
    {
        //starts the application, displays the menu, and processes the user's selections
        //until the user choose to exit.
        /// <summary>
        /// Starts the application, displays the menu, and processes the user's selections
        /// until the user chooses to exit.
        /// </summary>
        private static void Main()
        {
            Recipe? currentRecipe = null;
            bool isRunning = true;

            Console.WriteLine("=================================");
            Console.WriteLine("       RECIPE APPLICATION");
            Console.WriteLine("=================================");

            while (isRunning)
            {
                DisplayMenu();
                string choice = ReadRequiredText("Select an option: ").Trim();

                switch (choice)
                {
                    case "1":
                        currentRecipe = CreateRecipe();
                        break;

                    case "2":
                        DisplayCurrentRecipe(currentRecipe);
                        break;

                    case "3":
                        ScaleCurrentRecipe(currentRecipe);
                        break;

                    case "4":
                        ResetCurrentRecipe(currentRecipe);
                        break;

                    case "5":
                        currentRecipe = ClearCurrentRecipe(currentRecipe);
                        break;

                    case "6":
                        isRunning = false;
                        Console.WriteLine("Thank you for using the Recipe Application. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please enter a number from 1 to 6.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to return to the menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Prints the available actions that the user can perform.
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine("--------------- MENU ---------------");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display current recipe");
            Console.WriteLine("3. Scale recipe");
            Console.WriteLine("4. Reset ingredient quantities");
            Console.WriteLine("5. Clear recipe");
            Console.WriteLine("6. Exit");
            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Collects the recipe name, ingredient details, and preparation steps.
        /// The ingredients and steps are stored in arrays in memory.
        /// </summary>
        /// <returns>A newly created Recipe object.</returns>
        private static Recipe CreateRecipe()
        {
            Console.WriteLine();
            Console.WriteLine("----------- ENTER NEW RECIPE -----------");

            string recipeName = ReadRequiredText("Enter the recipe name: ");
            int ingredientCount = ReadPositiveInteger("How many ingredients are there? ");

            // Create an array with exactly the number of ingredients entered by the user.
            Ingredient[] ingredients = new Ingredient[ingredientCount];

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Ingredient {i + 1}:");

                string name = ReadRequiredText("  Enter ingredient name: ");
                decimal quantity = ReadNonNegativeDecimal("  Enter quantity: ", allowZero: false);
                string unit = ReadRequiredText("  Enter unit of measurement (e.g. cups, tablespoons, grams): ");

                // Each Ingredient stores both its original and current quantity.
                ingredients[i] = new Ingredient(name, quantity, unit);
            }

            Console.WriteLine();
            int stepCount = ReadPositiveInteger("How many preparation steps are there? ");

            // Store each preparation instruction in a string array.
            string[] steps = new string[stepCount];

            for (int i = 0; i < stepCount; i++)
            {
                steps[i] = ReadRequiredText($"Enter step {i + 1}: ");
            }

            Console.WriteLine();
            Console.WriteLine("Recipe created successfully.");
            return new Recipe(recipeName, ingredients, steps);
        }

        /// <summary>
        /// Displays the current recipe if one has been entered.
        /// </summary>
        /// <param name="recipe">The recipe to display, or null if no recipe exists.</param>
        private static void DisplayCurrentRecipe(Recipe? recipe)
        {
            if (recipe is null)
            {
                Console.WriteLine("There is no recipe to display. Please enter a recipe first.");
                return;
            }

            recipe.DisplayRecipe();
        }

        /// <summary>
        /// Asks the user for a supported scaling factor and applies it to the current recipe.
        /// </summary>
        /// <param name="recipe">The recipe whose ingredient quantities should be scaled.</param>
        private static void ScaleCurrentRecipe(Recipe? recipe)
        {
            if (recipe is null)
            {
                Console.WriteLine("There is no recipe to scale. Please enter a recipe first.");
                return;
            }

            Console.WriteLine("Choose a scaling factor:");
            Console.WriteLine("1. 0.5 - Half");
            Console.WriteLine("2. 2   - Double");
            Console.WriteLine("3. 3   - Triple");

            string choice = ReadRequiredText("Select an option: ").Trim();

            decimal factor;

            // Convert the menu choice into one of the three permitted scaling factors.
            switch (choice)
            {
                case "1":
                    factor = 0.5m;
                    break;
                case "2":
                    factor = 2m;
                    break;
                case "3":
                    factor = 3m;
                    break;
                default:
                    Console.WriteLine("Invalid scaling option. No changes were made.");
                    return;
            }

            recipe.ScaleRecipe(factor);
            Console.WriteLine($"Recipe quantities have been scaled by {factor}.");
            recipe.DisplayRecipe();
        }

        /// <summary>
        /// Restores every ingredient quantity to the value captured when the recipe was created.
        /// </summary>
        /// <param name="recipe">The recipe to reset, or null if no recipe exists.</param>
        private static void ResetCurrentRecipe(Recipe? recipe)
        {
            if (recipe is null)
            {
                Console.WriteLine("There is no recipe to reset. Please enter a recipe first.");
                return;
            }

            recipe.ResetQuantities();
            Console.WriteLine("All ingredient quantities have been restored to their original values.");
            recipe.DisplayRecipe();
        }

        /// <summary>
        /// Removes the current recipe from memory so that another recipe can be entered.
        /// </summary>
        /// <param name="recipe">The current recipe. It is not modified because the caller sets it to null.</param>
        /// <returns>Null, indicating that no recipe is currently stored.</returns>
        private static Recipe? ClearCurrentRecipe(Recipe? recipe)
        {
            if (recipe is null)
            {
                Console.WriteLine("There is no recipe to clear.");
                return null;
            }

            Console.Write($"Are you sure you want to clear '{recipe.Name}'? (Y/N): ");
            string confirmation = (Console.ReadLine() ?? string.Empty).Trim();

            if (confirmation.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Recipe cleared. You can now enter a new recipe.");
                return null;
            }

            Console.WriteLine("Clear operation cancelled. Your recipe is unchanged.");
            return recipe;
        }

        /// <summary>
        /// Reads a non-empty line of text from the console.
        /// </summary>
        /// <param name="prompt">The message shown before input is requested.</param>
        /// <returns>The trimmed text entered by the user.</returns>
        private static string ReadRequiredText(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = (Console.ReadLine() ?? string.Empty).Trim();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    return value;
                }

                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        }

        /// <summary>
        /// Reads an integer greater than zero, repeating the prompt when input is invalid.
        /// </summary>
        /// <param name="prompt">The message shown before input is requested.</param>
        /// <returns>A valid positive integer.</returns>
        private static int ReadPositiveInteger(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? string.Empty).Trim();

                if (int.TryParse(input, out int value) && value > 0)
                {
                    return value;
                }

                Console.WriteLine("Please enter a whole number greater than zero.");
            }
        }

        /// <summary>
        /// Reads a decimal quantity and validates whether zero is permitted.
        /// The current culture is used so decimal input follows the computer's regional settings.
        /// </summary>
        /// <param name="prompt">The message shown before input is requested.</param>
        /// <param name="allowZero">True when zero is allowed; otherwise the value must be positive.</param>
        /// <returns>A valid decimal quantity.</returns>
        private static decimal ReadNonNegativeDecimal(string prompt, bool allowZero)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? string.Empty).Trim();

                if (decimal.TryParse(input, out decimal value) &&
                    (allowZero ? value >= 0 : value > 0))
                {
                    return value;
                }

                Console.WriteLine(allowZero
                    ? "Please enter a valid number that is zero or greater."
                    : "Please enter a valid number greater than zero.");
            }
        }

    }


}

