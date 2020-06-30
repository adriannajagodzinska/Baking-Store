namespace OIprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianaKalorii : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipe", "Calories", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipe", "Calories", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
