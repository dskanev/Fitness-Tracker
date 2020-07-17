using FitnessTracker.Client.ViewModels.Recipes;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessTracker.Client.Services.Recipes
{
    public interface IRecipesService
    {
        [Get("/Recipes")]
        Task<IEnumerable<RecipeDetailsOutputModel>> All();

        [Get("/Recipes/{id}")]
        Task<RecipeDetailsOutputModel> Details(int id);

        [Put("/Recipes/{id}")]
        Task Edit(int id, RecipeInputModel recipe);
    }
}
