using FitnessTracker.Client.ViewModels.Recipes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Client.ViewModels.Homepage
{
    public class HomepageViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
        public IEnumerable<RecipeDetailsOutputModel> Recipes { get; set; }
    }
}
