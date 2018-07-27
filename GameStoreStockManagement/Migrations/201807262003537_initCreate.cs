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
                        Name = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GamePlatform",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Platform = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.InvoiceGame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Item_Id = c.Int(),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .ForeignKey("dbo.GamePlatform", t => t.Item_Id)
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .Index(t => t.InvoiceId)
                .Index(t => t.Item_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 5, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 5, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceGame", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.InvoiceGame", "Item_Id", "dbo.GamePlatform");
            DropForeignKey("dbo.InvoiceGame", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.GamePlatform", "GameId", "dbo.Game");
            DropForeignKey("dbo.GameGenres", "GameId", "dbo.Game");
            DropIndex("dbo.InvoiceGame", new[] { "Game_Id" });
            DropIndex("dbo.InvoiceGame", new[] { "Item_Id" });
            DropIndex("dbo.InvoiceGame", new[] { "InvoiceId" });
            DropIndex("dbo.GamePlatform", new[] { "GameId" });
            DropIndex("dbo.GameGenres", new[] { "GameId" });
            DropTable("dbo.Genre");
            DropTable("dbo.Invoice");
            DropTable("dbo.InvoiceGame");
            DropTable("dbo.GamePlatform");
            DropTable("dbo.Game");
            DropTable("dbo.GameGenres");
        }
    }
}
