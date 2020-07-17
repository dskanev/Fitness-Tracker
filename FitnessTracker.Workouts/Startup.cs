using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Infrastructure;
using FitnessTracker.Services;
using FitnessTracker.Workouts.Data;
using FitnessTracker.Workouts.Data.Models;
using FitnessTracker.Workouts.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FitnessTracker.Workouts
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<WorkoutsDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, WorkoutsDataSeeder>()
                .AddTransient<IExerciseService, ExerciseService>()
                .AddTransient<IWorkoutService, WorkoutService>()
                .AddMessaging();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
