using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.ViewModels.Workouts
{
    public class ExerciseOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int CaloriesPerRep { get; set; }
        public string Category { get; set; }
    }
}
