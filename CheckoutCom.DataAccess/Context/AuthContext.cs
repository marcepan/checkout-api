using Microsoft.AspNet.Identity.EntityFramework;

namespace CheckoutCom.DataAccess.Context
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}
