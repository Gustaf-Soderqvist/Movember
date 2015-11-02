using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;

namespace IZ.MovemberApp.Models
{
    public class IzMovemberContext : DbContext
    {

        public DbSet<Post> Post { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>().HasKey(m => m.Id);
            builder.Entity<Rating>().HasKey(m => m.RateId);
            builder.Entity<Post>().HasMany(p => p.Ratings).WithOne().ForeignKey(r => r.PostId);
            base.OnModelCreating(builder);
        }
    }


}
