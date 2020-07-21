using AutoMapper;
using FitnessTracker.Common.Messages;
using FitnessTracker.Services;
using FitnessTracker.Workouts.Data.Models;
using FitnessTracker.Workouts.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Services
{
    public class ExerciseService : DataService<Exercise>, IExerciseService
    {
        private readonly IMapper mapper;
        private readonly IBus publisher;

        public ExerciseService(WorkoutsDbContext db, IMapper mapper, IBus publisher)
            : base(db)
        {
            this.mapper = mapper;
            this.publisher = publisher;
        }
        

        public async Task<Exercise> Find(int id)
        => await this
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ExerciseOutputModel>> GetExercisesForUser(string userId)
        {
            var result = await this.mapper
                .ProjectTo<ExerciseOutputModel>(this.All())
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var recipe = await this.Data.FindAsync<Exercise>(id);

            if (recipe == null)
            {
                return false;
            }

            this.Data.Remove(recipe);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<ActionResult> TrackWorkout(string userId, ExerciseInputModel input)
        {
            var exercise = new Exercise
            {
                Name = input.Name,
                Sets = input.Sets,
                Reps = input.Reps,
                CaloriesPerRep = input.CaloriesPerRep,
                UserId = userId,
                ExerciseCategory = new ExerciseCategory { },
                Workout = new Workout { }
            };

            await this.Save(exercise);

            await this.publisher.Publish(new ExerciseTrackedMessage
            {
                UserId = userId,
                Calories = input.CaloriesPerRep * input.Reps * input.Sets
            });

            return Result.Success;
        }

    }
}
