using System.Threading.Tasks;
using System.Web.Http;
using CheckoutCom.BusinessLogic.Services;
using CheckoutCom.DataAccess.Models;

namespace CheckoutCom.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
         _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _authService.RegisterUser(userModel);

            return Ok();
        }
    }
}