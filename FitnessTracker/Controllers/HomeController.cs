using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FitnessTracker.Models;
using FitnessTracker.Infrastructure;
using FitnessTracker.Client.Services.Recipes;
using FitnessTracker.Client.Services.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FitnessTracker.Client.ViewModels;
using FitnessTracker.Client.ViewModels.Identity;
using FitnessTracker.Client.ViewModels.Homepage;
using FitnessTracker.Client.ViewModels.Recipes;
using FitnessTracker.Client.Services.Workouts;
using FitnessTracker.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using FitnessTracker.Client.Services.Meals;
using FitnessTracker.Common.Infrastructure;
using FitnessTracker.Client.ViewModels.Workouts;
using FitnessTracker.Client.ViewModels.Meals;
using FitnessTracker.Client.Services.Calories;
using FitnessTracker.Client.Services.UserHistory;

namespace FitnessTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityService identityService;
        private readonly IRecipesService recipesService;
        private readonly IMapper mapper;
        private readonly IWorkoutsService workoutsService;
        private readonly ICurrentUserService currentUser;
        private readonly IMealsService mealsService;
        private readonly ICaloriesService caloriesService;
        private readonly IUserHistoryService userHistory;

        public HomeController(
            IIdentityService identityService,
            IRecipesService recipesService,
            IWorkoutsService workoutsService,
            ICurrentUserService currentUser,
            IMapper mapper,
            IMealsService mealsService,
            ICaloriesService caloriesService,
            IUserHistoryService userHistory)
        {
            this.identityService = identityService;
            this.recipesService = recipesService;
            this.workoutsService = workoutsService;
            this.currentUser = currentUser;
            this.mapper = mapper;
            this.mealsService = mealsService;
            this.caloriesService = caloriesService;
            this.userHistory = userHistory;
        }
        public async Task<IActionResult> Index()
        {
            if (currentUser.UserId != null)
            {
                return RedirectToAction(nameof(HomeController.Homepage), "Home");
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Homepage()
        {
            var userId = currentUser.UserId;
            var model = new HomepageViewModel {};

            // if one microservice is down move on after the exception, ugly but no time for a cleaner solution

            try
            {
                model.Recipes = await this.recipesService.All();
            }
            catch { }
            try
            {
                model.Exercises = await this.workoutsService.GetExercisesByUser(userId);
            }
            catch { }
            try
            {
                model.Meals = await this.mealsService.GetMealsByUser(userId);
            }
            catch { }
            try
            {
                model.NetCalories = await this.caloriesService.NetCaloriesForUser(userId);
            }
            catch { }
            try
            {
                model.MealsTracked = await this.userHistory.MealsTracked(userId);
            }
            catch { }
            try
            {
                model.TotalCaloriesBurned = await this.userHistory.CaloriesBurned(userId);
            }
            catch { }

            return View(model);
        }

        public async Task<IActionResult> ShowRecipe(int id)
        {
            return View(await this.recipesService.Details(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
            });
    }
}
