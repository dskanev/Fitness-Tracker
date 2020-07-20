using FitnessTracker.Client.ViewModels.Meals;
using FitnessTracker.Client.ViewModels.Recipes;
using FitnessTracker.Client.ViewModels.Workouts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.ViewModels.Homepage
{
    public class HomepageViewModel
    {
        public IEnumerable<RecipeDetailsOutputModel> Recipes { get; set; } = new List<RecipeDetailsOutputModel>();
        public IEnumerable<ExerciseOutputModel> Exercises { get; set; } = new List<ExerciseOutputModel>();
        public IEnumerable<MealOutputModel> Meals { get; set; } = new List<MealOutputModel>();
    }
}
