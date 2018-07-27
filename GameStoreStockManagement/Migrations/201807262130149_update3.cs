namespace GameStoreStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform");
            DropIndex("dbo.InvoiceGame", new[] { "Item_Id" });
            AlterColumn("dbo.InvoiceGame", "Item_Id", c => c.Int());
            CreateIndex("dbo.InvoiceGame", "Item_Id");
            AddForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform");
            DropIndex("dbo.InvoiceGame", new[] { "Item_Id" });
            AlterColumn("dbo.InvoiceGame", "Item_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceGame", "Item_Id");
            AddForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform", "Id", cascadeDelete: true);
        }
    }
}
