using AutoMapper;
using FitnessTracker.Meals.Data;
using FitnessTracker.Meals.Data.Models;
using FitnessTracker.Meals.Models;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Services
{
    public class MealsService : DataService<Meal>, IMealsService
    {
        private readonly IMapper mapper;

        public MealsService(MealsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;


        public async Task<IEnumerable<Meal>> GetMealsByUser(string userId)
        {
            var result = await this.All()
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return result;
        }

        public async Task<ActionResult> TrackMeal(string userId, MealInputModel input)
        {
            var meal = new Meal
            {
                Name = input.Name,
                Protein = input.Protein,
                Carbs = input.Carbs,
                Fat = input.Fat,
                Calories = input.Calories,
                UserId = userId
            };

            await this.Save(meal);

            return Result.Success;
        }
    }
}
