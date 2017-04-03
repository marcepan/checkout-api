using System.Collections.Generic;
using CheckoutCom.BusinessLogic.DTO;

namespace CheckoutCom.DataAccess.Models
{
    public class DrinkList
    {
        public IEnumerable<DrinkDTO> Drinks { get; set; } 
    }
}
