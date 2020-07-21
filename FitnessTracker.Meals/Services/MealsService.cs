using AutoMapper;
using FitnessTracker.Common.Messages;
using FitnessTracker.Meals.Data;
using FitnessTracker.Meals.Data.Models;
using FitnessTracker.Meals.Models;
using FitnessTracker.Services;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Services
{
    public class MealsService : DataService<Meal>, IMealsService
    {
        private readonly IMapper mapper;
        private readonly IBus publisher;

        public MealsService(MealsDbContext db, IMapper mapper, IBus publisher)
            : base(db)
        {
            this.mapper = mapper;
            this.publisher = publisher;
        }      

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

            await this.publisher.Publish(new MealTrackedMessage
            {
                MealId = meal.Id,
                MealName = meal.Name,
                UserId = userId
            });

            return Result.Success;
        }
    }
}
