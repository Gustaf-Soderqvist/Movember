using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;

namespace IZ.MovemberApp.Models
{
    public class IzMovemberContext : DbContext
    {

        public DbSet<Post> Post { get; set; }

    }


}
