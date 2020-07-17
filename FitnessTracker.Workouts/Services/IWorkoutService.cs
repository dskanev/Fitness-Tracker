using FitnessTracker.Services;
using FitnessTracker.Workouts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Services
{
    public interface IWorkoutService : IDataService<Workout>
    {
        Task<Workout> Find(int id);
    }
}
