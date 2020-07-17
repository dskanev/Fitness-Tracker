using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Models.Recipes
{
    public class CreateRecipeOutputModel
    {
        public CreateRecipeOutputModel(int recipeId)
            => this.RecipeId = recipeId;

        public int RecipeId { get; }
    }
}
