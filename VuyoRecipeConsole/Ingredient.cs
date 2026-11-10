using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuyoRecipeConsole
{
    public class Ingredient
    {
        /// <summary>
        /// Gets or sets the ingredient's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity currently displayed for this ingredient.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit used to measure the ingredient, such as cups or grams.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets the quantity entered by the user before any scaling is applied.
        /// </summary>
        public decimal OriginalQuantity { get; }

        /// <summary>
        /// Initializes an ingredient and records its original quantity.
        /// </summary>
        /// <param name="name">The ingredient name.</param>
        /// <param name="quantity">The original ingredient quantity.</param>
        /// <param name="unit">The ingredient's unit of measurement.</param>
        public Ingredient(string name, decimal quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            OriginalQuantity = quantity;
            Unit = unit;
        }

        /// <summary>
        /// Sets the current quantity to the original quantity multiplied by a scaling factor.
        /// </summary>
        /// <param name="factor">The factor by which the original quantity is multiplied.</param>
        public void ScaleQuantity(decimal factor)
        {
            Quantity = OriginalQuantity * factor;
        }

        /// <summary>
        /// Restores the current quantity to the original value entered by the user.
        /// </summary>
        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;
        }
    }
}
