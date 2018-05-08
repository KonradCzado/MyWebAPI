namespace MyWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPictureField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Image");
        }
    }
}
