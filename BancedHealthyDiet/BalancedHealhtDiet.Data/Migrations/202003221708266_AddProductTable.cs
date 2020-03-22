namespace BancedHealthyDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductTable : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
