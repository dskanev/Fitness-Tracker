using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.Services.Calories
{
    public interface ICaloriesService
    {
        [Get("/Calories/{id}")]
        Task<long> NetCaloriesForUser(string id);
    }
}
