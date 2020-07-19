using FitnessTracker.Meals.Data.Models;
using FitnessTracker.Meals.Models;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Services
{
    public interface IMealsService : IDataService<Meal>
    {
        Task<IEnumerable<Meal>> GetMealsByUser(string userId);
        Task<ActionResult> TrackMeal(string userId, MealInputModel meal);
    }
}
