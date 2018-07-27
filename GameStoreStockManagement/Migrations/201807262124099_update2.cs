namespace GameStoreStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceGame", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.InvoiceGame", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform");
            DropIndex("dbo.InvoiceGame", new[] { "Item_Id" });
            DropIndex("dbo.InvoiceGame", new[] { "Game_Id" });
            AddColumn("dbo.Game", "Invoice_Id", c => c.Int());
            AlterColumn("dbo.GameGenres", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.GamePlatform", "Platform", c => c.String(nullable: false));
            AlterColumn("dbo.InvoiceGame", "Item_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoice", "SubTotal", c => c.Double(nullable: false));
            AlterColumn("dbo.Invoice", "Tax", c => c.Double(nullable: false));
            AlterColumn("dbo.Invoice", "TotalAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.Genre", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Game", "Invoice_Id");
            CreateIndex("dbo.InvoiceGame", "Item_Id");
            AddForeignKey("dbo.Game", "Invoice_Id", "dbo.Invoice", "Id");
            AddForeignKey("dbo.InvoiceGame", "InvoiceId", "dbo.Invoice", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform", "Id", cascadeDelete: true);
            DropColumn("dbo.GameGenres", "Name");
            DropColumn("dbo.InvoiceGame", "Game_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceGame", "Game_Id", c => c.Int());
            AddColumn("dbo.GameGenres", "Name", c => c.String());
            DropForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform");
            DropForeignKey("dbo.InvoiceGame", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Game", "Invoice_Id", "dbo.Invoice");
            DropIndex("dbo.InvoiceGame", new[] { "Item_Id" });
            DropIndex("dbo.Game", new[] { "Invoice_Id" });
            AlterColumn("dbo.Genre", "Name", c => c.String());
            AlterColumn("dbo.Invoice", "TotalAmount", c => c.Decimal(nullable: false, precision: 5, scale: 2));
            AlterColumn("dbo.Invoice", "Tax", c => c.Decimal(nullable: false, precision: 5, scale: 2));
            AlterColumn("dbo.Invoice", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceGame", "Item_Id", c => c.Int());
            AlterColumn("dbo.GamePlatform", "Platform", c => c.String());
            AlterColumn("dbo.GameGenres", "Genre", c => c.String());
            DropColumn("dbo.Game", "Invoice_Id");
            CreateIndex("dbo.InvoiceGame", "Game_Id");
            CreateIndex("dbo.InvoiceGame", "Item_Id");
            AddForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform", "Id");
            AddForeignKey("dbo.InvoiceGame", "InvoiceId", "dbo.Invoice", "Id");
            AddForeignKey("dbo.InvoiceGame", "Game_Id", "dbo.Game", "Id");
        }
    }
}
