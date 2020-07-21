using FitnessTracker.Calories.Gateway.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Calories.Gateway.Services
{
    public interface IWorkoutService
    {
        [Get("/Workouts/{id}")]
        Task<IEnumerable<ExerciseOutputModel>> GetExercisesByUser(string id);
    }
}
