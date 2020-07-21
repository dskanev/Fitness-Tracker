using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FitnessTracker.UserHistory.Data
{
    public class UserHistoryDbContext : DbContext
    {
        public UserHistoryDbContext(DbContextOptions<UserHistoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Data.Models.UserHistory> UserHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
