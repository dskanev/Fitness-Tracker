using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Data.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Calories { get; set; }
        public string UserId { get; set; }
    }
}
