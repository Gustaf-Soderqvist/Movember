using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IZ.MovemberApp.API
{
    [Route("api/[controller]")]
    public class UserStoreController : Controller
    {
        // GET: api/values
        [HttpPost("{email}")]
        public HttpStatusCodeResult SignIn(string email)
        {
            //user  = context.users.single(email)
            //if(user == null)
            if (false)
            {
                return new HttpUnauthorizedResult();
            }
         
            //skapa cookie
            HttpContext.Response.Cookies.Append("user", email);
            return new HttpOkResult();
        }

        // GET api/values/5
        [HttpPost()]
        public HttpStatusCodeResult SignOut()
        {
            if (HttpContext.Request.Cookies.ContainsKey("user"))
            {
                HttpContext.Response.Cookies.Delete("user");
            }

            return new HttpOkResult();
        }       
    }
}
