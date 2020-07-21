using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Common.Messages
{
    public class ExerciseTrackedMessage
    {
        public int ExerciseId { get; set; }
        public int Calories { get; set; }
        public string UserId { get; set; }
    }

}
