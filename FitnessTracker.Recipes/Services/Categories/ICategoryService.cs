using FitnessTracker.Recipes.Data.Models;
using FitnessTracker.Recipes.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Services.Categories
{
    public interface ICategoryService
    {
        Task<Category> Find(int categoryId);

        Task<IEnumerable<CategoryOutputModel>> GetAll();
    }
}
