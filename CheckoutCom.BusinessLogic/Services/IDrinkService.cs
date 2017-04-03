using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CheckoutCom.BusinessLogic.DTO;
using CheckoutCom.DataAccess.Models;

namespace CheckoutCom.BusinessLogic.Services
{
    public interface IDrinkService
    {
        IEnumerable<DrinkDTO> GetDrinks(Expression<Func<Drink, bool>> filter = null,
            Func<IQueryable<Drink>, IOrderedQueryable<Drink>> orderBy = null);

        DrinkDTO GetDrinkByName(string name);

        void AddDrink(DrinkDTO drink);

        void UpdateDrinkQuantity(string name, int quantity);

        void RemoveDrink(string name);
    }
}
