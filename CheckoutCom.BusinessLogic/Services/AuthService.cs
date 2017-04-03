using System.Threading.Tasks;
using CheckoutCom.DataAccess.Models;
using CheckoutCom.DataAccess.Repositories;
using Microsoft.AspNet.Identity;

namespace CheckoutCom.BusinessLogic.Services {
   public class AuthService : IAuthService
   {
      private readonly IAuthRepository _repository;

      public AuthService(IAuthRepository repository)
      {
         _repository = repository;
      }
      public async Task<IdentityResult> RegisterUser(UserModel userModel)
      {
         var result = await _repository.RegisterUser(userModel);
         return result;
      }
   }
}
