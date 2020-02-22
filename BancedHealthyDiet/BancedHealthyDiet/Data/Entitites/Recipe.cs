using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancedHealthyDiet.Data.Entitites
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string RecipeName{ get; set; }
        public string Instruction { get; set; }
        public double TotalWeight { get; set; }
        public virtual ICollection<Ingredient> Ingredients{ get; set; }

        public Recipe()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
