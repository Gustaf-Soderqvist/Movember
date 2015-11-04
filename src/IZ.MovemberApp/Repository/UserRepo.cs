using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using IZ.MovemberApp.Models;

namespace IZ.MovemberApp.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IzMovemberContext _dbContext;

        private readonly ILogger _logger;

        public UserRepo(IzMovemberContext db, ILoggerFactory loggerFactory)
        {
            _dbContext = db;
            _logger = loggerFactory.CreateLogger("IUserRepo");
        }
        public List<User> GetAll()
        {
            _logger.LogInformation("Getting all users");
            return _dbContext.User.ToList();
        }
        public User Get(string email)
        {
            return _dbContext.User.FirstOrDefault(t => t.Email == email);
        }
        [HttpPost]
        public void Post([FromBody] User user)
        {
            if(user.userId == Guid.Empty)
            {
                _dbContext.User.Add(user);
            }
            else
            {
                _dbContext.User.Update(user);
            }
        }
        public void Delete(Guid id)
        {
            var entity = _dbContext.User.First(t => t.userId == id);
            _dbContext.User.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
