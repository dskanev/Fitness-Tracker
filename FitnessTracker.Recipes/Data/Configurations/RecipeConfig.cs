using FitnessTracker.Recipes.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Data.Configurations
{
    internal class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(c => c.Instructions)
                .IsRequired()
                .HasMaxLength(5000);

            builder
                .Property(c => c.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(c => c.Micronutrients, micronutrients =>
                {
                    micronutrients.WithOwner();

                    micronutrients
                        .Property(mn => mn.Salt)
                        .IsRequired();

                    micronutrients
                        .Property(mn => mn.Potassium)
                        .IsRequired();
                });
        }
    }
}
