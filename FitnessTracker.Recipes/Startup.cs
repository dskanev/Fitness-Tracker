using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Infrastructure;
using FitnessTracker.Recipes.Data;
using FitnessTracker.Recipes.Services.Categories;
using FitnessTracker.Recipes.Services.Recipes;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FitnessTracker.Recipes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<RecipesDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, RecipesDataSeeder>()
                .AddTransient<IRecipeService, RecipeService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddMessaging();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
