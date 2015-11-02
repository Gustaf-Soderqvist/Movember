using System.Collections.Generic;
using IZ.MovemberApp.Models;
using Microsoft.AspNet.Mvc;
using System;

namespace IZ.MovemberApp.Repository
{
    public interface IUserRepo
    {
        void Delete(Guid id);
        User Get(Guid id);
        List<User> GetAll();
        void Post(User user);
    }
}
