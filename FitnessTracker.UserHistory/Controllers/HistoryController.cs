using FitnessTracker.Common.Controllers;
using FitnessTracker.Services;
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
        public async Task<int> MealsTracked(string id)
        {
            var result = await this.userHistoryService.MealsTracked(id);
            return result;
        } 
    }
}
