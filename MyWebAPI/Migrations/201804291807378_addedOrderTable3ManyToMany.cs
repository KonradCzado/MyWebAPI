namespace MyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrderTable3ManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Order_ID", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "Order_ID" });
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Product_ID = c.Int(nullable: false),
                        Order_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ID, t.Order_ID })
                .ForeignKey("dbo.Products", t => t.Product_ID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_ID, cascadeDelete: true)
                .Index(t => t.Product_ID)
                .Index(t => t.Order_ID);
            
            DropColumn("dbo.Products", "Order_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_ID", c => c.Int());
            DropForeignKey("dbo.ProductOrders", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.ProductOrders", "Product_ID", "dbo.Products");
            DropIndex("dbo.ProductOrders", new[] { "Order_ID" });
            DropIndex("dbo.ProductOrders", new[] { "Product_ID" });
            DropTable("dbo.ProductOrders");
            CreateIndex("dbo.Products", "Order_ID");
            AddForeignKey("dbo.Products", "Order_ID", "dbo.Orders", "ID");
        }
    }
}
