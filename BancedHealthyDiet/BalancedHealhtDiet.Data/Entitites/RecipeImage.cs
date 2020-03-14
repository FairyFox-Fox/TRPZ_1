using BancedHealthyDiet.Data.Interfaces;
using System;

namespace BalancedHealhtDiet.Data.Entitites
{
    public class RecipeImage:IEntity
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        //one to many
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public RecipeImage()
        {
            this.Id = Guid.NewGuid();
        }

        public RecipeImage(string imagePath, Recipe recipe):this()
        {
            ImagePath = imagePath;
            Recipe = recipe;
        }
    }
}