using FitnessTracker.Client.ViewModels.Workouts;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.Services.Workouts
{
    public interface IWorkoutsService
    {
        [Get("/Workouts/{id}")]
        Task<IEnumerable<ExerciseOutputModel>> GetExercisesByUser(string id);

        [Post("/Workouts/TrackWorkout")]
        Task<ActionResult> TrackWorkout([Body] WorkoutInputModel input);
    }
}
