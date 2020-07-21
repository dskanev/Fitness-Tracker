﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.Services
{
    public class ServiceEndpoints
    {
        public string Identity { get; private set; }
        public string Recipes { get; private set; }
        public string Workouts { get; private set; }
        public string Meals { get; private set; }
        public string CaloriesGateway { get; private set; }
        public string UserHistory { get; private set; }

        public string this[string service]
            => this.GetType()
                .GetProperties()
                .Where(pr => string
                    .Equals(pr.Name, service, StringComparison.CurrentCultureIgnoreCase))
                .Select(pr => (string)pr.GetValue(this))
                .FirstOrDefault()
                ?? throw new InvalidOperationException(
                    $"External service with name '{service}' does not exists.");
    }
}
