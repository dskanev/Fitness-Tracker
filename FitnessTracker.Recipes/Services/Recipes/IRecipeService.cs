using FitnessTracker.Recipes.Data.Models;
using FitnessTracker.Recipes.Models.Recipes;
using FitnessTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Services.Recipes
{
    public interface IRecipeService : IDataService<Recipe>
    {
        Task<Recipe> Find(int id);

        Task<bool> Delete(int id);

        Task<IEnumerable<RecipeOutputModel>> GetListings(RecipesQuery query);

        Task<IEnumerable<MineRecipeOutputModel>> Mine(int userId, RecipesQuery query);

        Task<RecipeDetailsOutputModel> GetDetails(int id);

        Task<int> Total(RecipesQuery query);

        Task<IEnumerable<RecipeOutputModel>> GetAll();
    }
}
