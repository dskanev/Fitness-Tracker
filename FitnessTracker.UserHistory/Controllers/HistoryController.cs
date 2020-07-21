using FitnessTracker.Common.Controllers;
using FitnessTracker.UserHistory.Models;
using FitnessTracker.UserHistory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.UserHistory.Controllers
{
    public class HistoryController : ApiController
    {
        private readonly IUserHistoryService userHistoryService;

        public HistoryController(IUserHistoryService userHistoryService)
            => this.userHistoryService = userHistoryService;

        [HttpGet]
        [Route(Id)]
        public async Task<int> MealsTracked(string userId)
            => await this.userHistoryService.MealsTracked(userId);
    }
}
