using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Common.Messages.Dealers
{
    public class RecipeCreatedMessage
    {
        public int RecipeId { get; set; }

        public string CategoryName { get; set; }

        public decimal Protein { get; set; }

        public int Price { get; set; }
    }
}
