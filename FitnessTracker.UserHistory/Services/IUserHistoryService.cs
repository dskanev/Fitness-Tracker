using FitnessTracker.UserHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.UserHistory.Services
{
    public interface IUserHistoryService
    {
        Task<int> MealsTracked(string userId);
        Task<int> CaloriesBurned(string userId);
        Task TrackMeal(string userId);
        Task TrackWorkout(string userId, int calories);
    }
}
