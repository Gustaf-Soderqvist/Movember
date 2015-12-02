using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IZ.MovemberApp.Repository;
using Newtonsoft.Json;
using Microsoft.AspNet.Http;

namespace IZ.MovemberApp.API
{
    [Route("api/[controller]")]
    public class UserStoreController : Controller
    {
        private readonly IUserRepo _userRebo;

        public UserStoreController(IUserRepo userRebo)
        {
            _userRebo = userRebo;
        }


        [HttpGet("{email}")]
        public ActionResult SignIn(string email)
        {
            var user = _userRebo.Get(email);
            if (user == null)
            {
                return new HttpNotFoundObjectResult("You have no power here! Only username@infozone.se is valid here");
            }

            //Create cookie
            Response.Cookies.Append("user", user.Email);
            return new HttpOkResult();
        }


        [HttpPost("signout")]
        public HttpStatusCodeResult SignOut()
        {
            if (Request.Cookies.ContainsKey("user"))
            {               
                var options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append("user", "", options);
              //  HttpContext.Response.Cookies.Delete("user");
            }

            return new HttpOkResult();
        }
    }
}
