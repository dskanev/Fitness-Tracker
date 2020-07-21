using System.Threading.Tasks;
using AutoMapper;
using FitnessTracker.Client.Services.Identity;
using FitnessTracker.Client.Services.Meals;
using FitnessTracker.Client.Services.Recipes;
using FitnessTracker.Client.Services.Workouts;
using FitnessTracker.Client.ViewModels.Meals;
using FitnessTracker.Client.ViewModels.Tracking;
using FitnessTracker.Client.ViewModels.Workouts;
using FitnessTracker.Controllers;
using FitnessTracker.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Client.Controllers
{
    public class TrackingController : Controller
    {
        private readonly IIdentityService identityService;
        private readonly IRecipesService recipesService;
        private readonly IMapper mapper;
        private readonly IWorkoutsService workoutsService;
        private readonly ICurrentUserService currentUser;
        private readonly IMealsService mealsService;

        public TrackingController(
            IIdentityService identityService,
            IRecipesService recipesService,
            IMapper mapper,
            IWorkoutsService workoutsService,
            ICurrentUserService currentUser,
            IMealsService mealsService)
        {
            this.identityService = identityService;
            this.recipesService = recipesService;
            this.mapper = mapper;
            this.workoutsService = workoutsService;
            this.currentUser = currentUser;
            this.mealsService = mealsService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> TrackWorkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> TrackMeal(TrackingFormModel model)
        {
            var param = this.mapper.Map<MealInputModel>(model);
            var result = await this.mealsService.TrackMeal(param);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> TrackWorkout(TrackingWorkoutModel model)
        {
            var param = this.mapper.Map<WorkoutInputModel>(model);
            var result = await this.workoutsService.TrackWorkout(param);
            return RedirectToAction("Index", "Home");
        }

    }
}
