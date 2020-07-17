using FitnessTracker.Services;
using FitnessTracker.Workouts.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Workouts.Data
{
    public class WorkoutsDataSeeder : IDataSeeder
    {
        private static IEnumerable<ExerciseCategory> GetData()
            => new List<ExerciseCategory>
            {
                new ExerciseCategory{ Name = "Push", Description = "Target muscles associated with pushing: pectorals, triceps, shoulders, etc." },
                new ExerciseCategory{ Name = "Pull", Description = "Target muscles associated with pulling movements: lats, biceps, etc." },
                new ExerciseCategory{ Name = "Legs", Description = "Targeting the quads, hams, glutes, etc." },
            };

        private readonly WorkoutsDbContext db;

        public WorkoutsDataSeeder(WorkoutsDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Categories.Any())
            {
                return;
            }

            foreach (var category in GetData())
            {
                this.db.Categories.Add(category);
            }

            this.db.SaveChanges();
        }
    }
}
