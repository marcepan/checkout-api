using System.Data.Entity;
using CheckoutCom.DataAccess.Models;

namespace CheckoutCom.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
    }
}
