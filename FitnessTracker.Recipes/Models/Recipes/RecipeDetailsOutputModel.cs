using AutoMapper;
using FitnessTracker.Recipes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Models.Recipes
{
    public class RecipeDetailsOutputModel : RecipeOutputModel
    {
        public int Salt { get; private set; }

        public int Potassium { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Recipe, RecipeDetailsOutputModel>()
                .IncludeBase<Recipe, RecipeOutputModel>()
                .ForMember(c => c.Salt, cfg => cfg
                    .MapFrom(c => c.Micronutrients.Salt))
                .ForMember(c => c.Potassium, cfg => cfg
                    .MapFrom(c => c.Micronutrients.Potassium));
    }
}
