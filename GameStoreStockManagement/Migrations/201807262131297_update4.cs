namespace GameStoreStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Game", "Invoice_Id", "dbo.Invoice");
            DropIndex("dbo.Game", new[] { "Invoice_Id" });
            DropColumn("dbo.Game", "Invoice_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Invoice_Id", c => c.Int());
            CreateIndex("dbo.Game", "Invoice_Id");
            AddForeignKey("dbo.Game", "Invoice_Id", "dbo.Invoice", "Id");
        }
    }
}
