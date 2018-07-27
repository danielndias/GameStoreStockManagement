namespace GameStoreStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GamePlatform", "InStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GamePlatform", "InStock");
        }
    }
}
