using CheckoutCom.DataAccess.Context;
using CheckoutCom.DataAccess.Models;

namespace CheckoutCom.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseContext context)
        {
            context.Drinks.AddOrUpdate(d =>
                new Drink { Name = "Pepsi", Quantity = 1 },
                new Drink { Name = "Coke", Quantity = 0 },
                new Drink { Name = "Tea", Quantity = 2 }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
