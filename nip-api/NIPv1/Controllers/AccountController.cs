using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using NIPv1.DAL_Interfaces;
using NIPv1.Models;

namespace NIPv1.Controllers
{
    /// <summary>
    /// Accounts controler class, all account related HTTP actions go through here.
    /// </summary>
    [System.Web.Mvc.RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IAuthorizationRepository authorizationRepository;

        public AccountController(IAuthorizationRepository authorizationRepository)
        {
            this.authorizationRepository = authorizationRepository;
        }

        /// <summary>
        /// HTTP GET for registering users. As parameter takes user model with user name, password and confirmed password
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await authorizationRepository.RegisterUser(userModel);
            var errorResult = GetErrorResult(result);
            return errorResult ?? Ok();
        }

        /// <summary>
        /// Disposes of all entities created for this class running.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) authorizationRepository.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Prepares error message for sending.
        /// </summary>
        /// <param name="result">data checkt after error</param>
        /// <returns>HttpActionResult</returns>
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null) return InternalServerError();
            if (result.Succeeded) return null;
            if (result.Errors != null)
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error);
            if (ModelState.IsValid) return BadRequest();
            return BadRequest(ModelState);
        }
    }
}