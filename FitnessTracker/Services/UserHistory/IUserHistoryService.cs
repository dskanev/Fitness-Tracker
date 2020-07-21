using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.Services.UserHistory
{
    public interface IUserHistoryService
    {
        [Get("/History/{id}")]
        Task<int> MealsTracked(string id);

        [Get("/History/CaloriesBurned/{id}")]
        Task<int> CaloriesBurned(string id);
    }
}
