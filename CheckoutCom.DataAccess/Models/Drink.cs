using System.ComponentModel.DataAnnotations;

namespace CheckoutCom.DataAccess.Models
{
    public class Drink
    {
        [Key]
        public int DrinkId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
