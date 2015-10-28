using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IZ.MovemberApp.Models;

namespace IZ.MovemberApp.Repository
{
    public interface IPostRebo
    {
        void Delete(long id);
        Post Get(long id);
        List<Post> GetAll();
        void Post(Post post);
        void Put(long id, [FromBody] Post post);
    }
}
