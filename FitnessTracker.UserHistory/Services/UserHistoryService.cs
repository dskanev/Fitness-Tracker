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
                => this.All().Where(x => x.UserId == userId).Count();

        public async Task TrackMeal(string userId)
        {
            var userHistory = await this.All().Where(x => x.UserId == userId).SingleOrDefaultAsync();

            userHistory.TrackedMeals++;

            await this.Data.SaveChangesAsync();
        }
    }
}
