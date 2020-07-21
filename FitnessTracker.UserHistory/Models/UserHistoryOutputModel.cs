using FitnessTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.UserHistory.Models
{
    public class UserHistoryOutputModel : IMapFrom<FitnessTracker.UserHistory.Data.Models.UserHistory>
    {
        public int TrackedMeals { get; set; }
    }
}
