using AutoMapper;
using FitnessTracker.Recipes.Data;
using FitnessTracker.Recipes.Data.Models;
using FitnessTracker.Recipes.Models.Recipes;
using FitnessTracker.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Services.Recipes
{
    public class RecipeService : DataService<Recipe>, IRecipeService
    {
        private const int ItemsPerPage = 10;

        private readonly IMapper mapper;

        public RecipeService(RecipesDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> Delete(int id)
        {
            var recipe = await this.Data.FindAsync<Recipe>(id);

            if (recipe == null)
            {
                return false;
            }

            this.Data.Remove(recipe);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Recipe> Find(int id)
        => await this
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        public async Task<RecipeDetailsOutputModel> GetDetails(int id)
         => await this.mapper
                .ProjectTo<RecipeDetailsOutputModel>(this
                    .All()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<RecipeOutputModel>> GetListings(RecipesQuery query)
        => (await this.mapper
                .ProjectTo<RecipeOutputModel>(this
                    .GetRecipesQuery(query))
                .ToListAsync())
                .Skip((query.Page - 1) * ItemsPerPage)
                .Take(ItemsPerPage);

        public async Task<IEnumerable<MineRecipeOutputModel>> Mine(int userId, RecipesQuery query)
        => (await this.mapper
                .ProjectTo<MineRecipeOutputModel>(this
                    .GetRecipesQuery(query, userId))
                .ToListAsync())
                .Skip((query.Page - 1) * ItemsPerPage)
                .Take(ItemsPerPage);

        public async Task<int> Total(RecipesQuery query)
        => await this
                .GetRecipesQuery(query)
                .CountAsync();

        private IQueryable<Recipe> GetRecipesQuery(
            RecipesQuery query, int? userId = null)
        {
            var dataQuery = this.All();

            if (userId.HasValue)
            {
                dataQuery = dataQuery.Where(c => c.UserId == userId);
            }

            if (query.Category.HasValue)
            {
                dataQuery = dataQuery.Where(c => c.CategoryId == query.Category);
            }

            return dataQuery;
        }

        public async Task<IEnumerable<RecipeOutputModel>> GetAll()
            => await this.mapper
                .ProjectTo<RecipeOutputModel>(this.All())
                .ToListAsync();
    }
}
