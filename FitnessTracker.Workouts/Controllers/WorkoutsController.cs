using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Common.Controllers;
using FitnessTracker.Services;
using FitnessTracker.Services.Identity;
using FitnessTracker.Workouts.Data.Models;
using FitnessTracker.Workouts.Services;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Workouts.Controllers
{
    public class WorkoutsController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IBus publisher;
        private readonly IExerciseService exerciseService;
        private readonly IWorkoutService workoutService;

        public WorkoutsController(
            ICurrentUserService currentUser,
            IBus publisher,
            IExerciseService exerciseService,
            IWorkoutService workoutService)
        {
            this.currentUser = currentUser;
            this.publisher = publisher;
            this.exerciseService = exerciseService;
            this.workoutService = workoutService;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<IEnumerable<Exercise>> GetExercisesByUser(string id)
        {
            var result = await this.exerciseService.GetExercisesForUser(id);
            return result;
        }
    }
}
