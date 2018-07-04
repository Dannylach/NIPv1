using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NIPv1.DAL_Interfaces;
using NIPv1.Entities;
using NIPv1.Models;

namespace NIPv1.DAL
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly AuthDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public AuthorizationRepository()
        {
            this.context = new AuthDbContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new IdentityUser {UserName = userModel.UserName};
            return await userManager.CreateAsync(user, userModel.Password);
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            return await userManager.FindAsync(userName, password);
        }

        public void Dispose()
        {
            context.Dispose();
            userManager.Dispose();

        }
    }
}