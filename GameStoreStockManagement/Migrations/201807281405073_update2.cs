namespace GameStoreStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform");
            DropIndex("dbo.InvoiceGame", new[] { "Item_Id" });
            DropPrimaryKey("dbo.GameGenres");
            DropPrimaryKey("dbo.GamePlatform");
            AddColumn("dbo.InvoiceGame", "Item_GameId", c => c.Int());
            AddPrimaryKey("dbo.GameGenres", new[] { "Id", "GameId" });
            AddPrimaryKey("dbo.GamePlatform", new[] { "Id", "GameId" });
            CreateIndex("dbo.InvoiceGame", new[] { "Item_Id", "Item_GameId" });
            AddForeignKey("dbo.InvoiceGame", new[] { "Item_Id", "Item_GameId" }, "dbo.GamePlatform", new[] { "Id", "GameId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceGame", new[] { "Item_Id", "Item_GameId" }, "dbo.GamePlatform");
            DropIndex("dbo.InvoiceGame", new[] { "Item_Id", "Item_GameId" });
            DropPrimaryKey("dbo.GamePlatform");
            DropPrimaryKey("dbo.GameGenres");
            DropColumn("dbo.InvoiceGame", "Item_GameId");
            AddPrimaryKey("dbo.GamePlatform", "Id");
            AddPrimaryKey("dbo.GameGenres", "Id");
            CreateIndex("dbo.InvoiceGame", "Item_Id");
            AddForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform", "Id");
        }
    }
}
