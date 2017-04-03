using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutCom.Api.Controllers;
using CheckoutCom.BusinessLogic.DTO;
using CheckoutCom.BusinessLogic.Services;
using CheckoutCom.DataAccess.Models;
using Moq;

namespace CheckoutCom.Api.Tests.Controllers
{
    [TestClass]
    public class DrinkControllerTests
    {
        private DrinkController _controller;
        private Mock<IDrinkService> _drinkServiceMock;

        [TestInitialize]
        public void Setup()
        {
            _drinkServiceMock = new Mock<IDrinkService>();

            _controller = new DrinkController(_drinkServiceMock.Object);
        }

        [TestMethod]
        public void GetAll_NoParameter_DrinkList()
        {
            // Arrange
            var returned = false;
            _drinkServiceMock.Setup(
                s =>
                    s.GetDrinks(It.IsAny<Expression<Func<Drink, bool>>>(),
                        It.IsAny<Func<IQueryable<Drink>, IOrderedQueryable<Drink>>>())).Callback(() => returned = true);

            // Act
            var res = _controller.GetAll();

            // Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(returned);
        }

        [TestMethod]
        public void Get_DrinkName_ParticularDrink()
        {
            // Arrange
            var returned = false;
            _drinkServiceMock.Setup(
                s =>
                    s.GetDrinkByName("DrinkName")).Callback(() => returned = true);

            // Act
            var res = _controller.Get("DrinkName");

            // Assert
            Assert.IsNotNull(res);
            Assert.IsTrue(returned);
        }

        [TestMethod]
        public void Delete_DrinkName_DrinkDeleted()
        {
            // Arrange
            var deleted = false;
            _drinkServiceMock.Setup(
                s =>
                    s.RemoveDrink("DrinkName")).Callback(() => deleted = true);

            // Act
            _controller.Delete("DrinkName");

            // Assert
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void Add_DrinkNameAndQuantity_DrinkAdded()
        {
            // Arrange
            var added = false;
            var drink = new DrinkDTO {Name = "DrinkName", Quantity = 1};
            _drinkServiceMock.Setup(
                s =>
                    s.AddDrink(drink)).Callback(() => added = true);

            // Act
            _controller.Add(drink);

            // Assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void Update_DrinkNameAndQuantity_DrinkAdded()
        {
            // Arrange
            var updated = false;
            _drinkServiceMock.Setup(
                s =>
                    s.UpdateDrinkQuantity("DrinkName", 1)).Callback(() => updated = true);

            // Act
            _controller.Update("DrinkName", new DrinkDTO {Quantity = 1});

            // Assert
            Assert.IsTrue(updated);
        }
    }
}
