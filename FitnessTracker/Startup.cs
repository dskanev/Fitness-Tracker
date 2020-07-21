using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FitnessTracker.Client.Infrastructure;
using FitnessTracker.Client.Services;
using FitnessTracker.Client.Services.Calories;
using FitnessTracker.Client.Services.Identity;
using FitnessTracker.Client.Services.Meals;
using FitnessTracker.Client.Services.Recipes;
using FitnessTracker.Client.Services.UserHistory;
using FitnessTracker.Client.Services.Workouts;
using FitnessTracker.Infrastructure;
using FitnessTracker.Services.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

namespace FitnessTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddTokenAuthentication(this.Configuration)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtCookieAuthenticationMiddleware>()
                .AddControllersWithViews(options => options
                    .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services
                .AddRefitClient<IIdentityService>()
                .WithConfiguration(serviceEndpoints.Identity);

            services
                .AddRefitClient<IRecipesService>()
                .WithConfiguration(serviceEndpoints.Recipes);

            services
                .AddRefitClient<IWorkoutsService>()
                .WithConfiguration(serviceEndpoints.Workouts);

            services
                .AddRefitClient<IMealsService>()
                .WithConfiguration(serviceEndpoints.Meals);

            services
                .AddRefitClient<ICaloriesService>()
                .WithConfiguration(serviceEndpoints.CaloriesGateway);

            services
                .AddRefitClient<IUserHistoryService>()
                .WithConfiguration(serviceEndpoints.UserHistory);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage();
            }
            else
            {
                app
                    .UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseJwtCookieAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapDefaultControllerRoute());
        }
    }
}
