namespace GameStoreStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Genre = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.GameId })
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Rating = c.String(nullable: false, maxLength: 3),
                        ReleaseYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GamePlatform",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Platform = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        InStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.GameId })
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.InvoiceGame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        QuantitySold = c.Int(nullable: false),
                        Item_Id = c.Int(),
                        Item_GameId = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id, t.ItemId })
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.GamePlatform", t => new { t.Item_Id, t.Item_GameId })
                .Index(t => t.InvoiceId)
                .Index(t => new { t.Item_Id, t.Item_GameId });
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Platform",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FieldId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamePlatform", "GameId", "dbo.Game");
            DropForeignKey("dbo.InvoiceGame", new[] { "Item_Id", "Item_GameId" }, "dbo.GamePlatform");
            DropForeignKey("dbo.InvoiceGame", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.GameGenres", "GameId", "dbo.Game");
            DropIndex("dbo.InvoiceGame", new[] { "Item_Id", "Item_GameId" });
            DropIndex("dbo.InvoiceGame", new[] { "InvoiceId" });
            DropIndex("dbo.GamePlatform", new[] { "GameId" });
            DropIndex("dbo.GameGenres", new[] { "GameId" });
            DropTable("dbo.Platform");
            DropTable("dbo.Genre");
            DropTable("dbo.Invoice");
            DropTable("dbo.InvoiceGame");
            DropTable("dbo.GamePlatform");
            DropTable("dbo.Game");
            DropTable("dbo.GameGenres");
        }
    }
}
