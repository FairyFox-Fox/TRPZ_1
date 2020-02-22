namespace BancedHealthyDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        Weight = c.Double(nullable: false),
                        MeasurementUnit = c.String(),
                        RecipeId = c.Int(nullable: false),
                        Product_Id = c.Guid(),
                        Recipe_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImagePath = c.String(),
                        RecipeName = c.String(),
                        Instruction = c.String(),
                        TotalWeight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Nutritions", "Id", "dbo.Products");
            DropIndex("dbo.Nutritions", new[] { "Id" });
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropIndex("dbo.Ingredients", new[] { "Product_Id" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Nutritions");
            DropTable("dbo.Products");
            DropTable("dbo.Ingredients");
        }
    }
}
