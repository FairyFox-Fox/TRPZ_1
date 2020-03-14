namespace BancedHealthyDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesRecipeImagesAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Nutritions", "Id", "dbo.Products");
            DropForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "Product_Id" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropIndex("dbo.Nutritions", new[] { "Id" });
            DropColumn("dbo.Ingredients", "RecipeId");
            RenameColumn(table: "dbo.Ingredients", name: "Recipe_Id", newName: "RecipeId");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CountOfRecipes = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImagePath = c.String(),
                        RecipeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            AddColumn("dbo.Products", "IngredientId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "Nutrition_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "Proteins", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Carbonhydrates", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Fats", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Vitamins", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Minerals", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Nutrition_Calories", c => c.Double(nullable: false));
            AddColumn("dbo.Recipes", "CategoryId", c => c.Guid(nullable: false));
            AddColumn("dbo.Recipes", "ShortDescription", c => c.String());
            AddColumn("dbo.Recipes", "RecipeDetails_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Recipes", "VideoPath", c => c.String());
            AddColumn("dbo.Recipes", "Notes", c => c.String());
            AddColumn("dbo.Recipes", "IsFavourite", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "Source", c => c.String());
            AddColumn("dbo.Recipes", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "NumberOfServings", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "CookTime", c => c.Long(nullable: false));
            AlterColumn("dbo.Ingredients", "RecipeId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Ingredients", "RecipeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Recipes", "CategoryId");
            CreateIndex("dbo.Ingredients", "RecipeId");
            CreateIndex("dbo.Products", "IngredientId");
            AddForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "IngredientId", "dbo.Ingredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            DropColumn("dbo.Ingredients", "Product_Id");
            DropColumn("dbo.Recipes", "ImagePath");
            DropTable("dbo.Nutritions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Nutritions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Proteins = c.Double(nullable: false),
                        Carbonhydrates = c.Double(nullable: false),
                        Fats = c.Double(nullable: false),
                        Vitamins = c.Double(nullable: false),
                        Minerals = c.Double(nullable: false),
                        Calories = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipes", "ImagePath", c => c.String());
            AddColumn("dbo.Ingredients", "Product_Id", c => c.Guid());
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Products", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeImages", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "IngredientId" });
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            DropIndex("dbo.RecipeImages", new[] { "RecipeId" });
            DropIndex("dbo.Recipes", new[] { "CategoryId" });
            AlterColumn("dbo.Ingredients", "RecipeId", c => c.Guid());
            AlterColumn("dbo.Ingredients", "RecipeId", c => c.Int(nullable: false));
            DropColumn("dbo.Recipes", "CookTime");
            DropColumn("dbo.Recipes", "NumberOfServings");
            DropColumn("dbo.Recipes", "Rating");
            DropColumn("dbo.Recipes", "Source");
            DropColumn("dbo.Recipes", "IsFavourite");
            DropColumn("dbo.Recipes", "Notes");
            DropColumn("dbo.Recipes", "VideoPath");
            DropColumn("dbo.Recipes", "RecipeDetails_Id");
            DropColumn("dbo.Recipes", "ShortDescription");
            DropColumn("dbo.Recipes", "CategoryId");
            DropColumn("dbo.Products", "Nutrition_Calories");
            DropColumn("dbo.Products", "Minerals");
            DropColumn("dbo.Products", "Vitamins");
            DropColumn("dbo.Products", "Fats");
            DropColumn("dbo.Products", "Carbonhydrates");
            DropColumn("dbo.Products", "Proteins");
            DropColumn("dbo.Products", "Nutrition_Id");
            DropColumn("dbo.Products", "IngredientId");
            DropTable("dbo.RecipeImages");
            DropTable("dbo.Categories");
            RenameColumn(table: "dbo.Ingredients", name: "RecipeId", newName: "Recipe_Id");
            AddColumn("dbo.Ingredients", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Nutritions", "Id");
            CreateIndex("dbo.Ingredients", "Recipe_Id");
            CreateIndex("dbo.Ingredients", "Product_Id");
            AddForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes", "Id");
            AddForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Nutritions", "Id", "dbo.Products", "Id");
        }
    }
}
