namespace MyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrderTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "Order_ID", c => c.Int());
            CreateIndex("dbo.Products", "Order_ID");
            AddForeignKey("dbo.Products", "Order_ID", "dbo.Orders", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_ID" });
            DropColumn("dbo.Products", "Order_ID");
            DropTable("dbo.Orders");
        }
    }
}
