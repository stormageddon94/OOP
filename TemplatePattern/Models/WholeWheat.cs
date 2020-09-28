using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern.Models
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering Ingredients for Whole Wheat Bread."); 
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
        }
    }
}
