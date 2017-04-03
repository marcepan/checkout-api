using System.Threading.Tasks;
using CheckoutCom.BusinessLogic.Services;
using CheckoutCom.DataAccess.Models;
using CheckoutCom.DataAccess.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CheckoutCom.BusinessLogic.Tests.Services
{
   [TestClass]
   public class AuthServiceTests
   {
      private IAuthService _authService;
      private Mock<IAuthRepository> _authRepositoryMock
         ;
      [TestInitialize]
      public void Setup()
      {
         _authRepositoryMock = new Mock<IAuthRepository>();

         _authService = new AuthService(_authRepositoryMock.Object);
      }

      [TestMethod]
      public void RegisterUser_UserModel_Registered()
      {
         // Arrange
         var taskToReturn = new Task<IdentityResult>(() => IdentityResult.Success);
         var registered = false;
         _authRepositoryMock.Setup(s => s.RegisterUser(It.IsAny<UserModel>())).Callback(() => registered = true);

         // Act
         _authService.RegisterUser(new UserModel());

         // Assert
         Assert.IsTrue(registered);
      }
   }
}
