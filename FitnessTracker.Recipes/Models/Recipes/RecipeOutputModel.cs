using AutoMapper;
using FitnessTracker.Models;
using FitnessTracker.Recipes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Models.Recipes
{
    public class RecipeOutputModel : IMapFrom<Recipe>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Protein { get; set; }

        public decimal Carbs { get; set; }

        public decimal Fat { get; set; }

        public int Price { get; set; }

        public int PreparationTime { get; set; }

        public string Category { get; set; }

        public string Instructions { get; set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Recipe, RecipeOutputModel>()
                .ForMember(ad => ad.Category, cfg => cfg
                    .MapFrom(ad => ad.Category.Name));
    }
}
