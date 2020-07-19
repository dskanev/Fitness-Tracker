using AutoMapper;
using FitnessTracker.Services;
using FitnessTracker.Workouts.Data.Models;
using FitnessTracker.Workouts.Models;
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

        public ExerciseService(WorkoutsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

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

    }
}
