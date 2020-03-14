using BalancedHealhtDiet.Data.Entitites;
using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BalancedHealhtDiet.Data.Entitites
{
    public class Recipe:IEntity
    {
        public Guid Id { get; set; }
        //one to many
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<RecipeImage> Images { get; set; }
        public string RecipeName{ get; set; }
        public string ShortDescription { get; set; }
        public double TotalWeight { get; set; }
        public virtual RecipeDetails RecipeDetails { get; set; }
        public virtual ICollection<Ingredient> Ingredients{ get; set; }

        public Recipe()
        {
            this.Id = Guid.NewGuid();
        }

        public Recipe( Category category, ICollection<RecipeImage> images,
            string recipeName, string shortDescription, double totalWeight,
            RecipeDetails recipeDetails):this()
        {
            Category = category;
            Images = images;
            RecipeName = recipeName;
            ShortDescription = shortDescription;
            TotalWeight = totalWeight;
            RecipeDetails = recipeDetails;
        }
    }
}
