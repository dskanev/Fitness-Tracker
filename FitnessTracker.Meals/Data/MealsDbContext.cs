using FitnessTracker.Meals.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FitnessTracker.Meals.Data
{
    public class MealsDbContext : DbContext
    {
        public MealsDbContext(DbContextOptions<MealsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
