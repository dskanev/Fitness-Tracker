using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Data.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int CaloriesPerRep { get; set; }
        public int CategoryId { get; set; }
        public int WorkoutId { get; set; }
        public ExerciseCategory Category { get; set; }
        public Workout Workout { get; set; }
        public string UserId { get; set; }
    }
}
