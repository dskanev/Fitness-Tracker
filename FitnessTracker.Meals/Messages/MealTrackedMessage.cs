using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Messages
{
    public class MealTrackedMessage
    {
        public int MealId { get; set; }

        public string MealName { get; set; }
    }
}
