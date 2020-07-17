using AutoMapper;
using FitnessTracker.Models;
using FitnessTracker.Recipes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Models.Categories
{
    public class CategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int TotalRecipes { get; set; }

        public void Mapping(Profile profile)
            => profile
                .CreateMap<Category, CategoryOutputModel>()
                .ForMember(c => c.TotalRecipes, cfg => cfg
                    .MapFrom(c => c.Recipes.Count()));
    }
}
