using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Common.Controllers;
using FitnessTracker.Services;
using FitnessTracker.Services.Identity;
using FitnessTracker.Workouts.Data.Models;
using FitnessTracker.Workouts.Models;
using FitnessTracker.Workouts.Services;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Workouts.Controllers
{
    public class WorkoutsController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IBus publisher;
        private readonly IExerciseService exerciseService;

        public WorkoutsController(
            ICurrentUserService currentUser,
            IBus publisher,
            IExerciseService exerciseService)
        {
            this.currentUser = currentUser;
            this.publisher = publisher;
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        [Route(Id)]
        [Authorize]
        public async Task<IEnumerable<ExerciseOutputModel>> GetExercisesByUser(string id)
        {
            var result = await this.exerciseService.GetExercisesForUser(id);
            return result;
        }

        [HttpPost]
        [Route(nameof(TrackWorkout))]
        [Authorize]
        public async Task<ActionResult> TrackWorkout(ExerciseInputModel input)
        {
            var result = await this.exerciseService.TrackWorkout(this.currentUser.UserId, input);
            return result;
        } 

    }
}
