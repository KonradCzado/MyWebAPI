namespace MyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrderShippingType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ShippingType");
        }
    }
}
