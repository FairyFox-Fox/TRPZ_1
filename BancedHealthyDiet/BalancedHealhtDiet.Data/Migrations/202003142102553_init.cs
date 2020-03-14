namespace BancedHealthyDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CountOfRecipes = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        RecipeName = c.String(),
                        ShortDescription = c.String(),
                        TotalWeight = c.Double(nullable: false),
                        RecipeDetails_Id = c.Guid(nullable: false),
                        VideoPath = c.String(),
                        Notes = c.String(),
                        Instruction = c.String(),
                        IsFavourite = c.Boolean(nullable: false),
                        Source = c.String(),
                        Rating = c.Int(nullable: false),
                        NumberOfServings = c.Int(nullable: false),
                        CookTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.RecipeImage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImagePath = c.String(),
                        RecipeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Weight = c.Double(nullable: false),
                        MeasurementUnit = c.String(),
                        RecipeId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductName = c.String(),
                        IngredientId = c.Guid(),
                        Nutrition_Id = c.Guid(nullable: false),
                        Proteins = c.Double(nullable: false),
                        Carbonhydrates = c.Double(nullable: false),
                        Fats = c.Double(nullable: false),
                        Vitamins = c.Double(nullable: false),
                        Minerals = c.Double(nullable: false),
                        Nutrition_Calories = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId)
                .Index(t => t.IngredientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredient", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Product", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.RecipeImage", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "IngredientId" });
            DropIndex("dbo.Ingredient", new[] { "RecipeId" });
            DropIndex("dbo.RecipeImage", new[] { "RecipeId" });
            DropIndex("dbo.Recipe", new[] { "CategoryId" });
            DropTable("dbo.Product");
            DropTable("dbo.Ingredient");
            DropTable("dbo.RecipeImage");
            DropTable("dbo.Recipe");
            DropTable("dbo.Category");
        }
    }
}
