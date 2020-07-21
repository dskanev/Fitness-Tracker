using FitnessTracker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.ViewModels.Recipes
{
    public class RecipeInputModel : IMapFrom<RecipeFormModel>
    {
        public int Category { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
        public int Price { get; set; }
        public int PreparationTime { get; set; }
        public int Salt { get; set; }
        public int Potassium { get; set; }
        public string Instructions { get; set; }
    }
}
