﻿using FitnessTracker.Identity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Identity.Services.Identity
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
