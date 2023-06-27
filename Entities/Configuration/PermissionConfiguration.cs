using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnline.IDP.Common;

namespace ShopOnline.IDP.Entities.Configuration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permisions", SystemConstants.IdentitySchema)
                    .HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.HasIndex(x => new { x.RoleId, x.Function, x.Command })
                .IsUnique();
        }
    }
}
