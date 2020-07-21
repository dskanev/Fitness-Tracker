using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.Services.UserHistory
{
    public interface IUserHistoryService
    {
        [Get("/UserHistory/{id}")]
        Task<int> MealsTracked(string id);
    }
}
