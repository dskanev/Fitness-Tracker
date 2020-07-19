using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Models
{
    public class CreateMealOutputModel
    {
        public CreateMealOutputModel(int mealId)
            => this.MealId = mealId;

        public int MealId { get; }
    }
}
