using FitnessTracker.Identity.Data.Models;
using FitnessTracker.Identity.Models.Identity;
using FitnessTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Identity.Services.Identity
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);
        Task<Result<UserOutputModel>> Login(UserInputModel userInput);
        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
