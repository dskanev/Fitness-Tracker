using AutoMapper;
using FitnessTracker.Recipes.Data;
using FitnessTracker.Recipes.Data.Models;
using FitnessTracker.Recipes.Models.Categories;
using FitnessTracker.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Services.Categories
{
    public class CategoryService : DataService<Category>, ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(RecipesDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Category> Find(int categoryId)
            => await this.Data.FindAsync<Category>(categoryId);

        public async Task<IEnumerable<CategoryOutputModel>> GetAll()
            => await this.mapper
                .ProjectTo<CategoryOutputModel>(this.All())
                .ToListAsync();
    }
}
