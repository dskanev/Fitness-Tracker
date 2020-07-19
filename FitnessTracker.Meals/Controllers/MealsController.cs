using FitnessTracker.Common.Controllers;
using FitnessTracker.Meals.Data.Models;
using FitnessTracker.Meals.Models;
using FitnessTracker.Meals.Services;
using FitnessTracker.Services.Identity;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Controllers
{
    public class MealsController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IBus publisher;
        private readonly IMealsService mealsService;

        public MealsController(
            ICurrentUserService currentUser,
            IBus publisher,
            IMealsService mealsService)
        {
            this.currentUser = currentUser;
            this.publisher = publisher;
            this.mealsService = mealsService;
        }

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<IEnumerable<Meal>> GetMealsByUser(string id)
        {
            var result = await this.mealsService.GetMealsByUser(id);
            return result;
        }

        [HttpPost]
        [Route(nameof(TrackMeal))]
        public async Task<ActionResult> TrackMeal(MealInputModel input)
        => await this.mealsService.TrackMeal(this.currentUser.UserId, input);
    }

}
