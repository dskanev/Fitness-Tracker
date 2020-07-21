using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.UserHistory.Services
{
    public interface IUserHistoryService
    {
        Task TrackMeal();
    }
}
