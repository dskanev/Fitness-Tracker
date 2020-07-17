using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Data.Models
{
    public class Workout
    {
        public int Id { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }

        public int TotalCalories { get; set; }

        public string UserId { get; set; }
    }
}
