using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuyoRecipeConsole
{
    // <summary>
    /// Represents a recipe, including its ingredients and preparation instructions.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the array containing all ingredients in this recipe.
        /// </summary>
        public Ingredient[] Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the array containing the recipe's preparation steps.
        /// </summary>
        public string[] Steps { get; set; }

        /// <summary>
        /// Initializes a recipe with its name, ingredient array, and preparation-step array.
        /// </summary>
        /// <param name="name">The recipe name.</param>
        /// <param name="ingredients">The ingredients that make up the recipe.</param>
        /// <param name="steps">The preparation instructions in the order they should be followed.</param>
        public Recipe(string name, Ingredient[] ingredients, string[] steps)
        {
            Name = name;
            Ingredients = ingredients;
            Steps = steps;
        }

        /// <summary>
        /// Displays the recipe name, ingredient quantities, units, and numbered preparation steps.
        /// </summary>
        public void DisplayRecipe()
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine($"             {Name.ToUpperInvariant()}");
            Console.WriteLine("========================================");

            Console.WriteLine();
            Console.WriteLine("INGREDIENTS");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredient ingredient = Ingredients[i];
                Console.WriteLine($"{i + 1}. {ingredient.Quantity:0.##} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine();
            Console.WriteLine("PREPARATION STEPS");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }

            Console.WriteLine("========================================");
        }

        /// <summary>
        /// Scales all ingredient quantities from their original values by the supplied factor.
        /// Scaling always uses OriginalQuantity, preventing repeated scaling from compounding.
        /// </summary>
        /// <param name="factor">The permitted scaling factor: 0.5, 2, or 3.</param>
        public void ScaleRecipe(decimal factor)
        {
            if (factor != 0.5m && factor != 2m && factor != 3m)
            {
                throw new ArgumentOutOfRangeException(nameof(factor), "Only 0.5, 2, or 3 are supported.");
            }

            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ScaleQuantity(factor);
            }
        }

        /// <summary>
        /// Resets every ingredient to the original quantity entered when the recipe was created.
        /// </summary>
        public void ResetQuantities()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
    }
}
