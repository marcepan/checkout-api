namespace CheckoutCom.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drinks",
                c => new
                {
                    DrinkId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.DrinkId);

        }
        
        public override void Down()
        {
            DropIndex("dbo.Drinks", new[] { "Name" });
            DropTable("dbo.Drinks");
        }
    }
}
