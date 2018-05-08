namespace MyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProducert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "ProducerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProducerID");
            AddForeignKey("dbo.Products", "ProducerID", "dbo.Producers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProducerID", "dbo.Producers");
            DropIndex("dbo.Products", new[] { "ProducerID" });
            DropColumn("dbo.Products", "ProducerID");
            DropTable("dbo.Producers");
        }
    }
}
