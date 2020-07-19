using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Models
{
    public class MealInputModel
    {
        public string Name { get; set; }
        public int Category { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Calories { get; set; }
    }
}
