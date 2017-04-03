using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CheckoutCom.BusinessLogic.DTO;
using CheckoutCom.BusinessLogic.Services;
using CheckoutCom.DataAccess.Models;
using CheckoutCom.DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CheckoutCom.BusinessLogic.Tests.Services
{
    [TestClass]
    public class DrinkServiceTests
    {
        private IDrinkService _drinkService;
        private Mock<IRepository<Drink>> _drinkRepositoryMock;
        private List<Drink> _drinkList;

        [TestInitialize]
        public void Setup()
        {
            _drinkList = new List<Drink>
            {
                new Drink {DrinkId = 1, Name = "Pepsi", Quantity = 1},
                new Drink {DrinkId = 2, Name = "Coke", Quantity = 2}
            };

            _drinkRepositoryMock =  new Mock<IRepository<Drink>>();
            _drinkRepositoryMock.Setup(s => s.Get(It.IsAny<Expression<Func<Drink, bool>>>(),
                It.IsAny<Func<IQueryable<Drink>, IOrderedQueryable<Drink>>>())).Returns(_drinkList);

            _drinkService = new DrinkService(_drinkRepositoryMock.Object);
        }

        [TestMethod]
        public void Get_DefaultParameters_DrinkList()
        {
            // Arrange

            // Act
            var res = _drinkService.GetDrinks();
            var list = res.ToList();

            // Assert
            Assert.AreEqual(_drinkList.Count, list.Count);
            Assert.AreEqual(_drinkList[0].Name, list[0].Name);
            Assert.AreEqual(_drinkList[1].Name, list[1].Name);
            Assert.AreEqual(_drinkList[0].Quantity, list[0].Quantity);
            Assert.AreEqual(_drinkList[1].Quantity, list[1].Quantity);
        }

        [TestMethod]
        public void GetDrinkByName_Pepsi_Pepsi()
        {
            // Arrange
            

            // Act
            var res = _drinkService.GetDrinkByName("Pepsi");

            // Assert
            Assert.AreEqual("Pepsi", res.Name);
        }

        [TestMethod]
        public void Add_NewDrink_DrinkAddedAndSaved()
        {
            // Arrange
            var added = false;
            var saved = false;
            var drink = new DrinkDTO {Name = "Fanta", Quantity = 3};
            _drinkRepositoryMock.Setup(s => s.Insert(It.IsAny<Drink>())).Callback(() => added = true);
            _drinkRepositoryMock.Setup(s => s.Save()).Callback(() => saved = true);
            _drinkRepositoryMock.Setup(s => s.Get(It.IsAny<Expression<Func<Drink, bool>>>(),
                It.IsAny<Func<IQueryable<Drink>, IOrderedQueryable<Drink>>>())).Returns(new List<Drink>());

            // Act
            _drinkService.AddDrink(drink);

            // Assert
            Assert.IsTrue(added);
            Assert.IsTrue(saved);
        }

        [TestMethod]
        public void Add_ExistingDrink_ArgumentExceptionWithMessage()
        {
            // Arrange
            var drink = new DrinkDTO { Name = "Pepsi", Quantity = 3 };
            // Act
            try
            {
                _drinkService.AddDrink(drink);
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("Duplicate drink", ex.Message);
            }
        }

        [TestMethod]
        public void Update_NonExistingDrink_DrinkNotUpdated()
        {
            // Arrange
            var updated = false;
            var saved = false;
            _drinkRepositoryMock.Setup(s => s.Update(It.IsAny<Drink>())).Callback(() => updated = true);
            _drinkRepositoryMock.Setup(s => s.Save()).Callback(() => saved = true);
            _drinkRepositoryMock.Setup(s => s.Get(It.IsAny<Expression<Func<Drink, bool>>>(),
                It.IsAny<Func<IQueryable<Drink>, IOrderedQueryable<Drink>>>())).Returns(new List<Drink>());

            // Act
            _drinkService.UpdateDrinkQuantity("Fanta", 100);

            // Assert
            Assert.IsFalse(updated);
            Assert.IsFalse(saved);
        }

        [TestMethod]
        public void Update_ExistingDrink_DrinktUpdatedAndSaved()
        {
            // Arrange
            var updated = false;
            var saved = false;
            _drinkRepositoryMock.Setup(s => s.Update(It.IsAny<Drink>())).Callback(() => updated = true);
            _drinkRepositoryMock.Setup(s => s.Save()).Callback(() => saved = true);

            // Act
            _drinkService.UpdateDrinkQuantity("Pepsi", 100);

            // Assert
            Assert.AreEqual(100, _drinkList.Find(d => d.Name == "Pepsi").Quantity);
            Assert.IsTrue(updated);
            Assert.IsTrue(saved);
        }

        [TestMethod]
        public void Remove_ExistingDrink_DrinkDeletedAndSaved()
        {
            // Arrange
            var deleted = false;
            var saved = false;
            _drinkRepositoryMock.Setup(s => s.Delete(It.IsAny<Drink>())).Callback(() => deleted = true);
            _drinkRepositoryMock.Setup(s => s.Save()).Callback(() => saved = true);

            // Act
            _drinkService.RemoveDrink("Pepsi");

            // Assert
            Assert.IsTrue(deleted);
            Assert.IsTrue(saved);
        }

        [TestMethod]
        public void Remove_NonExistingDrink_DrinkNotDeleted()
        {
            // Arrange
            var deleted = false;
            var saved = false;
            _drinkRepositoryMock.Setup(s => s.Delete(It.IsAny<Drink>())).Callback(() => deleted = true);
            _drinkRepositoryMock.Setup(s => s.Save()).Callback(() => saved = true);
            _drinkRepositoryMock.Setup(s => s.Get(It.IsAny<Expression<Func<Drink, bool>>>(),
                It.IsAny<Func<IQueryable<Drink>, IOrderedQueryable<Drink>>>())).Returns(new List<Drink>());

            // Act
            _drinkService.RemoveDrink("Fanta");

            // Assert
            Assert.IsFalse(deleted);
            Assert.IsFalse(saved);
        }
    }
}
