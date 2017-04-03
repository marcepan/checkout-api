namespace CheckoutCom.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdated : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Drinks", new[] { "Name" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Drinks", "Name", unique: true);
        }
    }
}
