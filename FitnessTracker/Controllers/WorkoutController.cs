using System.Threading.Tasks;
using AutoMapper;
using FitnessTracker.Client.Services.Identity;
using FitnessTracker.Client.Services.Recipes;
using FitnessTracker.Client.Services.Workouts;
using FitnessTracker.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Client.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IIdentityService identityService;
        private readonly IRecipesService recipesService;
        private readonly IMapper mapper;
        private readonly IWorkoutsService workoutsService;
        private readonly ICurrentUserService currentUser;

        public WorkoutController(
            IIdentityService identityService,
            IRecipesService recipesService,
            IMapper mapper,
            IWorkoutsService workoutsService,
            ICurrentUserService currentUser)
        {
            this.identityService = identityService;
            this.recipesService = recipesService;
            this.mapper = mapper;
            this.workoutsService = workoutsService;
            this.currentUser = currentUser;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.currentUser.UserId;
            var exercises = await this.workoutsService.GetExercisesByUser(userId);
            return View();
        }
    }
}
