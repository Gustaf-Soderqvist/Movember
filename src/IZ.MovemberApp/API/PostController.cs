using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IZ.MovemberApp.Models;
using Microsoft.Data.Entity.Storage;
using IZ.MovemberApp.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IZ.MovemberApp.API
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostRebo _postRebo;

        public PostController(IPostRebo postRebo)
        {
            _postRebo = postRebo;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _postRebo.GetAll();
        }

        [HttpGet("{id}")]
        public Post Get(long id)
        {
            return _postRebo.Get(id);
        }

        [HttpPost]
        public void Post(long id, [FromBody] Post value)
        {
            _postRebo.Post(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Post value)
        {
            _postRebo.Put(id,value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _postRebo.Delete(id);
        }
    }
}
