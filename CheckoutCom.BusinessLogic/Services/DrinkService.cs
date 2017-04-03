using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CheckoutCom.BusinessLogic.DTO;
using CheckoutCom.BusinessLogic.Extensions;
using CheckoutCom.DataAccess.Models;
using CheckoutCom.DataAccess.Repositories;

namespace CheckoutCom.BusinessLogic.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IRepository<Drink> _repository;

        public DrinkService(IRepository<Drink> repo)
        {
            _repository = repo;
        }

        public IEnumerable<DrinkDTO> GetDrinks(Expression<Func<Drink, bool>> filter = null, Func<IQueryable<Drink>, IOrderedQueryable<Drink>> orderBy = null)
        {
            return _repository.Get(filter, orderBy).Select(d => d.ToDTO());
        }

        public DrinkDTO GetDrinkByName(string name)
        {
            return _repository.Get(d => d.Name == name).FirstOrDefault().ToDTO();
        }

        public void AddDrink(DrinkDTO drink)
        {
            if (_repository.Get(d => d.Name == drink.Name).FirstOrDefault() != null)
            {
                throw new ArgumentException("Duplicate drink");
            }
            var newDrink = new Drink { Name = drink.Name, Quantity = drink.Quantity };
            _repository.Insert(newDrink);
            _repository.Save();
        }

        public void UpdateDrinkQuantity(string name, int quantity)
        {
            var existingDrink = _repository.Get(d => d.Name == name).FirstOrDefault();
            if (existingDrink == null) return;
            existingDrink.Quantity = quantity;
            _repository.Update(existingDrink);
            _repository.Save();
        }

        public void RemoveDrink(string name)
        {
            var existingDrink = _repository.Get(d => d.Name == name).FirstOrDefault();
            if (existingDrink == null) return;
            _repository.Delete(existingDrink);
            _repository.Save();
        }
    }
}
