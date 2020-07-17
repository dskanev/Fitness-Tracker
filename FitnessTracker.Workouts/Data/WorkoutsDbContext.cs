using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Data.Models
{
    public class WorkoutsDbContext : DbContext
    {
        public WorkoutsDbContext(DbContextOptions<WorkoutsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<ExerciseCategory> Categories { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
