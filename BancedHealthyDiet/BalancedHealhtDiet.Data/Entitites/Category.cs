
using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedHealhtDiet.Data.Entitites
{
    public class Category:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CountOfRecipes { get; set; }
        public string ImagePath { get; set; }
        //many recipes
        public virtual ICollection<Recipe> Recipes { get; set; }
        public Category()
        {
            this.Id = Guid.NewGuid();
        }

        public Category(string name, int countOfRecipes, string imagePath) : this()
        {
            Name = name;
            CountOfRecipes = countOfRecipes;
            ImagePath = imagePath;
        }
    }
}
