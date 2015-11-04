using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IZ.MovemberApp.Repository;
using IZ.MovemberApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IZ.MovemberApp.API
{
    [Route("api/[controller]")]
    public class UserDataController : Controller
    {

        private readonly IUserRepo _userRebo;

        public UserDataController(IUserRepo userRebo)
        {
            _userRebo = userRebo;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRebo.GetAll();
        }

        [HttpGet("{Email}")]
        public User Get(string email)
        {
            return _userRebo.Get(email);
        }
        [HttpPost]
        public void Post(Guid id, [FromBody] User value)
        {
            _userRebo.Post(value);
        }

        [HttpDelete("{userId}")]
        public void Delete(Guid id)
        {
            _userRebo.Delete(id);
        }
    }
}
