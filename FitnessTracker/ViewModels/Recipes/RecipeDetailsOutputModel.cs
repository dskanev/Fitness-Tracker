using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.ViewModels.Recipes
{
    public class RecipeDetailsOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Protein { get; set; }

        public decimal Carbs { get; set; }

        public decimal Fat { get; set; }

        public int Price { get; set; }

        public int PreparationTime { get; set; }

        public string Category { get; set; }
        public string Instructions { get; set; }
    }
}
