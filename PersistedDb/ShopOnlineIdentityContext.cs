using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopOnline.IDP.Entities;
using ShopOnline.IDP.Entities.Configuration;

namespace ShopOnline.IDP.PersistedDb
{
    public class ShopOnlineIdentityContext : IdentityDbContext<User>
    {
        public ShopOnlineIdentityContext(DbContextOptions<ShopOnlineIdentityContext> options):base(options)
        {
        }
        public DbSet<Permission> Permissions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ShopOnlineIdentityContext).Assembly);
            builder.ApplyIdentityConfiguration();
        }

    }
}
