namespace OIprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false, maxLength: 200),
                        CaloriesQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientID);
            
            CreateTable(
                "dbo.Measurement",
                c => new
                    {
                        MeasurementID = c.Int(nullable: false, identity: true),
                        MeasurementName = c.String(),
                    })
                .PrimaryKey(t => t.MeasurementID);
            
            CreateTable(
                "dbo.Quantity",
                c => new
                    {
                        QuantityID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        IngredientQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IngredientID = c.Int(nullable: false),
                        MeasurementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuantityID)
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Measurement", t => t.MeasurementID, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.IngredientID)
                .Index(t => t.MeasurementID);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(nullable: false, maxLength: 300),
                        Sources = c.String(maxLength: 400),
                        Preparation = c.String(),
                        Date = c.DateTime(nullable: false),
                        Calories = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quantity", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.Quantity", "MeasurementID", "dbo.Measurement");
            DropForeignKey("dbo.Quantity", "IngredientID", "dbo.Ingredient");
            DropIndex("dbo.Quantity", new[] { "MeasurementID" });
            DropIndex("dbo.Quantity", new[] { "IngredientID" });
            DropIndex("dbo.Quantity", new[] { "RecipeID" });
            DropTable("dbo.Recipe");
            DropTable("dbo.Quantity");
            DropTable("dbo.Measurement");
            DropTable("dbo.Ingredient");
        }
    }
}
