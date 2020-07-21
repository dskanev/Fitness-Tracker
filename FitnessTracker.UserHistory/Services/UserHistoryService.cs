using AutoMapper;
using FitnessTracker.Services;
using FitnessTracker.UserHistory.Data;
using FitnessTracker.UserHistory.Data.Models;
using FitnessTracker.UserHistory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.UserHistory.Services
{
    public class UserHistoryService : DataService<Data.Models.UserHistory>, IUserHistoryService
    {
        private readonly IMapper mapper;

    public UserHistoryService(UserHistoryDbContext db, IMapper mapper)
        : base(db)
    {
        this.mapper = mapper;
    }
        public async Task<int> MealsTracked(string userId)
        {
            var results = this.All()
                .Where(x => x.UserId == userId)
                .Select(x => x.TrackedMeals)
                .FirstOrDefault();

            return results;
        }

        public async Task TrackMeal(string userId)
        {
            var userHistory = await this.All().Where(x => x.UserId == userId).SingleOrDefaultAsync();

            if(userHistory == null)
            {
                userHistory = new Data.Models.UserHistory()
                {
                    UserId = userId,
                    TrackedMeals = 0
                };
                await this.Save(userHistory);
            }

            userHistory.TrackedMeals++;

            await this.Data.SaveChangesAsync();
        }

        public async Task TrackWorkout(string userId, int calories)
        {
            var userHistory = await this.All().Where(x => x.UserId == userId).SingleOrDefaultAsync();

            if (userHistory == null)
            {
                userHistory = new Data.Models.UserHistory()
                {
                    UserId = userId,
                    TotalCalories = 0
                };
                await this.Save(userHistory);
            }

            userHistory.TotalCalories = userHistory.TotalCalories + calories;

            await this.Data.SaveChangesAsync();
        }

        public async Task<int> CaloriesBurned(string userId)
        {
            var results = this.All()
                .Where(x => x.UserId == userId)
                .Select(x => x.TotalCalories)
                .FirstOrDefault();

            return results;
        }
    }
}
