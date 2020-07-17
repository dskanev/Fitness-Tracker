using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.ViewModels.Workouts
{
    public class WorkoutOutputModel
    {
        public int Id { get; set; }

        public IEnumerable<ExerciseOutputModel> Exercises { get; set; }

        public int TotalCalories { get; set; }

        public int UserId { get; set; }
    }
}
