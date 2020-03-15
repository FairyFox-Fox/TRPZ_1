
using BalancedHealhtDiet.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;



namespace BalancedHealhtDiet.Data.Configuration
{
    public class BalanceDietAppContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        //public DbSet<RecipeDetails> RecipeDetails { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
       // public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Product> Products { get; set; }

        public BalanceDietAppContext() : base("DefaultConnection")
        {

        }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.ComplexType<Nutrition>();
            modelBuilder.Entity<Product>().Property(x => x.Nutrition.Minerals).HasColumnName("Minerals");
            modelBuilder.Entity<Product>().Property(x => x.Nutrition.Proteins).HasColumnName("Proteins");
            modelBuilder.Entity<Product>().Property(x => x.Nutrition.Vitamins).HasColumnName("Vitamins");
            modelBuilder.Entity<Product>().Property(x => x.Nutrition.Carbonhydrates).HasColumnName("Carbonhydrates");
            modelBuilder.Entity<Product>().Property(x => x.Nutrition.Fats).HasColumnName("Fats");
            modelBuilder.ComplexType<RecipeDetails>();
            modelBuilder.Entity<Recipe>().Property(x => x.RecipeDetails.CookTime).HasColumnName("CookTime");
            modelBuilder.Entity<Recipe>().Property(x => x.RecipeDetails.Instruction).HasColumnName("Instruction");
            modelBuilder.Entity<Recipe>().Property(x => x.RecipeDetails.IsFavourite).HasColumnName("IsFavourite");
            modelBuilder.Entity<Recipe>().Property(x => x.RecipeDetails.Notes).HasColumnName("Notes");
            modelBuilder.Entity<Recipe>().Property(x => x.RecipeDetails.NumberOfServings).HasColumnName("NumberOfServings");
            modelBuilder.Entity<Recipe>().Property(x => x.RecipeDetails.Rating).HasColumnName("Rating");
            modelBuilder.Entity<Recipe>().Property(x => x.RecipeDetails.Source).HasColumnName("Source");
            modelBuilder.Entity<Recipe>().Property(x => x.RecipeDetails.VideoPath).HasColumnName("VideoPath");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
