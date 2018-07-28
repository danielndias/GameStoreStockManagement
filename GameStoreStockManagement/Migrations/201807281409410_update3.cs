namespace GameStoreStockManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.InvoiceGame");
            AddPrimaryKey("dbo.InvoiceGame", new[] { "Id", "InvoiceId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.InvoiceGame");
            AddPrimaryKey("dbo.InvoiceGame", "Id");
        }
    }
}
