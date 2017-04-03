using CheckoutCom.Api.Controllers;
using CheckoutCom.BusinessLogic.Services;
using CheckoutCom.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CheckoutCom.Api.Tests.Controllers
{
   [TestClass]
   public class AuthControllerTests
   {
      private AuthController _controller;
      private Mock<IAuthService> _authServiceMock;

      [TestInitialize]
      public void Setup()
      {
         _authServiceMock = new Mock<IAuthService>();

         _controller = new AuthController(_authServiceMock.Object);
      }

      [TestMethod]
      public void Register_UserModel_UserRegistered()
      {
         // Arrange
         var registered = false;
         _authServiceMock.Setup(s => s.RegisterUser(It.IsAny<UserModel>())).Callback(() => registered = true);

         // Act
         var res = _controller.Register(new UserModel());

         // Assert
         Assert.IsNotNull(res);
         Assert.IsTrue(registered);
      }
   }
}
