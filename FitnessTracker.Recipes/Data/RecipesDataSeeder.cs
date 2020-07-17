using FitnessTracker.Recipes.Data.Models;
using FitnessTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Data
{
    public class RecipesDataSeeder : IDataSeeder
    {
        private static IEnumerable<Category> GetData()
            => new List<Category>
            {
                new Category{ Name = "Breakfast", Description = "Easy to digest and perfect to start the day." },
                new Category{ Name = "Lunch", Description = "More substantial than breakfast but not too heavy." },
                new Category{ Name = "Pre-Workout", Description = "Very light and quick to digest." },
                new Category{ Name = "Post-Workout", Description = "Typically high in carbs for replenishing depleted muscle glycogen." },
                new Category{ Name = "Dinner", Description = "High in fat and protein, slow to digest." }
            };

        private readonly RecipesDbContext db;

        public RecipesDataSeeder(RecipesDbContext db) => this.db = db;

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
