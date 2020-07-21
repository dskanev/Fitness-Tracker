using AutoMapper;
using FitnessTracker.Calories.Gateway.Services;
using FitnessTracker.Common.Controllers;
using MassTransit.Initializers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FitnessTracker.Calories.Gateway.Controllers
{
    public class CaloriesController : ApiController
    {
        private readonly IWorkoutService workoutsService;
        private readonly IMealsService mealsService;
        private readonly IMapper mapper;

        public CaloriesController(
            IWorkoutService workoutsService,
            IMealsService mealsService,
            IMapper mapper)
        {
            this.workoutsService = workoutsService;
            this.mealsService = mealsService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<long> NetCaloriesForUser(string id)
        {
            var workouts = await workoutsService.GetExercisesByUser(id);
            var meals = await mealsService.GetMealsByUser(id);

            var workoutCalories = workouts.Select(x => new { x.Sets, x.Reps, x.CaloriesPerRep }).ToList();
            var caloricIntake = meals.Select(x => x.Calories).ToList();

            var calories = 0;

            foreach (var foodCal in caloricIntake)
            {
                calories += foodCal;
            }

            foreach (var workCal in workoutCalories)
            {
                calories -= (workCal.Sets * workCal.Reps * workCal.CaloriesPerRep);
            }

            return calories;
        }
    }
}
