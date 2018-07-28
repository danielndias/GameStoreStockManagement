namespace GameStoreStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameGenres", "GameId", "dbo.Game");
            DropForeignKey("dbo.GamePlatform", "GameId", "dbo.Game");
            AddForeignKey("dbo.GameGenres", "GameId", "dbo.Game", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GamePlatform", "GameId", "dbo.Game", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamePlatform", "GameId", "dbo.Game");
            DropForeignKey("dbo.GameGenres", "GameId", "dbo.Game");
            AddForeignKey("dbo.GamePlatform", "GameId", "dbo.Game", "Id");
            AddForeignKey("dbo.GameGenres", "GameId", "dbo.Game", "Id");
        }
    }
}
