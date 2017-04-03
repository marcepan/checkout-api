using System.Threading.Tasks;
using CheckoutCom.DataAccess.Models;
using Microsoft.AspNet.Identity;

namespace CheckoutCom.BusinessLogic.Services {
   public interface IAuthService
   {
      Task<IdentityResult> RegisterUser(UserModel userModel);
   }
}
