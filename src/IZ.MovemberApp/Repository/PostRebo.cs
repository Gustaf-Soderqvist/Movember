using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using IZ.MovemberApp.Models;

namespace IZ.MovemberApp.Repository
{
    public class PostRebo : IPostRebo
    {
        private readonly IzMovemberContext _dbContext;

        private readonly ILogger _logger;

        public PostRebo(IzMovemberContext db, ILoggerFactory loggerFactory)
        {
            _dbContext = db;
            _logger = loggerFactory.CreateLogger("IPostRebo");
        }

        public List<Post> GetAll()
        {
            _logger.LogCritical("Getting all posts");
            return _dbContext.Post.ToList();
        }

        public Post Get(long id)
        {
            return _dbContext.Post.First(t => t.Id == id);
        }

        [HttpPost]
        public void Post([FromBody]Post post)
        {

            if (post.Id == 0)
            {
                _dbContext.Post.Add(post);
            }
            else
            {
                //var toUpdate = _dbContext.Post.First(p => p.Id == post.Id);
                //toUpdate.Description = post.Description;
                //toUpdate.Name = post.Name;

                _dbContext.Post.Update(post);
            }



            _dbContext.SaveChanges();
        }

        public void Put(long id, [FromBody] Post post)
        {
            _dbContext.Post.Update(post);
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _dbContext.Post.First(t => t.Id == id);
            _dbContext.Post.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
