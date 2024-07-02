using Clean_Code_Services.Core.Entities.User;
using Clean_Code_Services.Core.Entities.Video;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean_Code_Services.Infrastructure.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<VideoUpload> VideoUploads { get; set; }
        public DbSet<AppUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VideoUpload>()
                .HasQueryFilter(b => !b.Deactivated);

            builder.Entity<AppUser>()
              .HasQueryFilter(b => !b.Deactivated);
        }

    }
}
