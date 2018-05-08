namespace MyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrde : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsShipped", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "TotalOrderCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "ShippingType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ShippingType", c => c.String());
            DropColumn("dbo.Orders", "TotalOrderCost");
            DropColumn("dbo.Orders", "IsShipped");
        }
    }
}
