using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using IZ.MovemberApp.Models;
using Microsoft.Data.Entity.Storage;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IZ.MovemberApp.API
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IzMovemberContext _dbContext;

        public PostController(IzMovemberContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _dbContext.Post;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var post = _dbContext.Post.FirstOrDefault(m => m.Id == id);
            if (post == null)
            {
                return new HttpNotFoundResult();
            }
            return new ObjectResult(post);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post post, Author author)
        {
            try
            {
                if (post.Id == 0)
                {
                    _dbContext.Post.Add(post);
                    _dbContext.SaveChanges();
                    return new ObjectResult(post);
                }
                var original = _dbContext.Post.FirstOrDefault(m => m.Id == post.Id);
                original.Name = post.Name;
                original.Description = post.Description;
                original.Image = post.Image;
                original.Author.FirstName = post.Author.FirstName;
                original.Author.LastName = post.Author.LastName;

                _dbContext.SaveChanges();
                return new ObjectResult(original);
            }
            catch (DataStoreException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes");
            }
            return new ObjectResult(post);
        }
             

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var post = _dbContext.Post.FirstOrDefault(m => m.Id == id);
            _dbContext.Post.Remove(post);
            _dbContext.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
    }
}
