using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using eShopSolution.Data.Entities;

namespace eShopSolution.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("AppRoles");
            //builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
        }
    }
}
