using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FitnessTracker.Models;
using FitnessTracker.Infrastructure;
using FitnessTracker.Client.Services.Recipes;
using FitnessTracker.Client.Services.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FitnessTracker.Client.ViewModels;
using FitnessTracker.Client.ViewModels.Identity;
using FitnessTracker.Client.ViewModels.Homepage;
using FitnessTracker.Client.ViewModels.Recipes;

namespace FitnessTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityService identityService;
        private readonly IRecipesService recipesService;
        private readonly IMapper mapper;

        public HomeController(
            IIdentityService identityService,
            IRecipesService recipesService,
            IMapper mapper)
        {
            this.identityService = identityService;
            this.recipesService = recipesService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model = new HomepageViewModel
            {
                Recipes = await this.recipesService.All()
            };   
            
            return View(model);
        }

        public async Task<IActionResult> ShowRecipe(int id)
        {
            return View(await this.recipesService.Details(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
            });
    }
}
