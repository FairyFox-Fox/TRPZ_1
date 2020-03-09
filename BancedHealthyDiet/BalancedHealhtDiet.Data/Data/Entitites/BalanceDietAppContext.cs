
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Text;



namespace BancedHealthyDiet.Data.Entitites
{
    public class BalanceDietAppContext:DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }
        public BalanceDietAppContext() : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }

    }
}
