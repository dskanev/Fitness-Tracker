using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.UserHistory.Data.Models
{
    public class UserHistory
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int TrackedMeals { get; set; }
    }
}
