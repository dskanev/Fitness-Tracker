using FitnessTracker.Workouts.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Workouts.Data.Configurations
{
    public class ExerciseConfiurations : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(c => c.UserId)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasOne(c => c.ExerciseCategory)
                .WithMany(c => c.Exercises)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Workout)
                .WithMany(x => x.Exercises)
                .HasForeignKey(x => x.WorkoutId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
