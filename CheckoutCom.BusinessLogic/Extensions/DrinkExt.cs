using CheckoutCom.BusinessLogic.DTO;
using CheckoutCom.DataAccess.Models;

namespace CheckoutCom.BusinessLogic.Extensions
{
    public static class DrinkExt
    {
        public static DrinkDTO ToDTO(this Drink drink)
        {
            return drink != null ? new DrinkDTO {Name = drink.Name, Quantity = drink.Quantity} : null;
        }
    }
}
