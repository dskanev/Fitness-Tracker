using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.ViewModels.Meals
{
    public class MealOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public string Calories { get; set; }
    }
}
