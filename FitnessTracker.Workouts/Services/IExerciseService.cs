﻿using FitnessTracker.Services;
using FitnessTracker.Workouts.Data.Models;
using FitnessTracker.Workouts.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Services
{
    public interface IExerciseService : IDataService<Exercise>
    {
        Task<Exercise> Find(int id);

        Task<bool> Delete(int id);

        Task<IEnumerable<ExerciseOutputModel>> GetExercisesForUser(string userId);

        Task<ActionResult> TrackWorkout(string userId, ExerciseInputModel input);
    }
}
