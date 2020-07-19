﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Common.Controllers;
using FitnessTracker.Common.Messages.Dealers;
using FitnessTracker.Infrastructure;
using FitnessTracker.Recipes.Data.Models;
using FitnessTracker.Recipes.Models.Recipes;
using FitnessTracker.Recipes.Services.Categories;
using FitnessTracker.Recipes.Services.Recipes;
using FitnessTracker.Services;
using FitnessTracker.Services.Identity;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Recipes.Controllers
{
    public class RecipesController : ApiController
    {
        private readonly IRecipeService recipes;
        private readonly ICategoryService categories;
        private readonly ICurrentUserService currentUser;
        private readonly IBus publisher;
        
        public RecipesController(
            IRecipeService recipes,
            ICategoryService categories,
            ICurrentUserService currentUser,
            IBus publisher)
        {
            this.recipes = recipes;
            this.categories = categories;
            this.currentUser = currentUser;
            this.publisher = publisher;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<RecipeDetailsOutputModel>> Details(int id)
            => await this.recipes.GetDetails(id);
        
        [HttpGet]
        public async Task<IEnumerable<RecipeOutputModel>> All()
            => await this.recipes.GetAll();

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateRecipeOutputModel>> Create(RecipeInputModel input)
        {
            var user = this.currentUser.UserId;

            var category = await this.categories.Find(input.Category);

            if (category == null)
            {
                return BadRequest(Result.Failure("Category does not exist."));
            }            

            var recipe = new Recipe
            {
                Name = input.Name,
                ImageUrl = input.ImageUrl,
                Protein = input.Protein,
                Carbs = input.Carbs,
                Fat = input.Fat,
                Price = input.Price,
                PreparationTime = input.PreparationTime,
                User = user,
                Category = category,
                Micronutrients = new Micronutrients
                {
                    Salt = input.Salt,
                    Potassium = input.Potassium
                }
            };

            await this.recipes.Save(recipe);

            await this.publisher.Publish(new RecipeCreatedMessage
            {
                RecipeId = recipe.Id,
                Protein = recipe.Protein,
                CategoryName = recipe.Category.Name,
                Price = recipe.Price
            });

            return new CreateRecipeOutputModel(recipe.Id);
        }
    }
}