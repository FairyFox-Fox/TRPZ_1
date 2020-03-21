namespace BancedHealthyDiet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CahngeIngredProdRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "IngredientId", "dbo.Ingredient");
            DropIndex("dbo.Product", new[] { "IngredientId" });
            AddColumn("dbo.Ingredient", "ProductId", c => c.Guid());
            CreateIndex("dbo.Ingredient", "ProductId");
            AddForeignKey("dbo.Ingredient", "ProductId", "dbo.Product", "Id");
            DropColumn("dbo.Product", "IngredientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "IngredientId", c => c.Guid());
            DropForeignKey("dbo.Ingredient", "ProductId", "dbo.Product");
            DropIndex("dbo.Ingredient", new[] { "ProductId" });
            DropColumn("dbo.Ingredient", "ProductId");
            CreateIndex("dbo.Product", "IngredientId");
            AddForeignKey("dbo.Product", "IngredientId", "dbo.Ingredient", "Id");
        }
    }
}
