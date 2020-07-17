using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Models.Recipes
{
    public class RecipesQuery
    {
        public int? Category { get; set; }

        public string User { get; set; }

        public string SortBy { get; set; }

        public string Order { get; set; }

        public int Page { get; set; } = 1;
    }
}
