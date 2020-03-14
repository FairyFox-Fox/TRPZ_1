
using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BalancedHealhtDiet.Data.Entitites
{
    public class Ingredient:IEntity
    {
        
        public Guid Id { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string MeasurementUnit { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient()
        {
            this.Id = Guid.NewGuid();
        }

        public Ingredient(string name, double weight, 
            string measurementUnit, Recipe recipe):this()
        {
            Name = name;
            Weight = weight;
            MeasurementUnit = measurementUnit;
            Recipe = recipe;
        }
    }
}
