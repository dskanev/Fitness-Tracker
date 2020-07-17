using AutoMapper;
using FitnessTracker.Services;
using FitnessTracker.Workouts.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Services
{
    public class WorkoutService : DataService<Workout>, IWorkoutService
    {
        private readonly IMapper mapper;

        public WorkoutService(WorkoutsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Workout> Find(int id)
        {
            var result = await this
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return result;
        } 
    }
}
