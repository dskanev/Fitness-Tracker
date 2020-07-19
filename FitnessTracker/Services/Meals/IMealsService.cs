using FitnessTracker.Client.ViewModels.Meals;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.Services.Meals
{
    public interface IMealsService
    {
        [Get("/Meals/{id}")]
        Task<IEnumerable<MealOutputModel>> GetMealsByUser(string id);

        [Post("/Meals/TrackMeal")]
        Task<ActionResult> TrackMeal([Body] MealInputModel input);
    }
}
