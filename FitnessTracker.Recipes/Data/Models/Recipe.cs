using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Recipes.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Protein { get; set; }

        public decimal Carbs { get; set; }

        public decimal Fat { get; set; }

        public int Price { get; set; }

        public int PreparationTime { get; set; }       

        public int? UserId { get; set; }
        
        public string User { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Micronutrients Micronutrients { get; set; }

        public string Instructions { get; set; }
    }
}
