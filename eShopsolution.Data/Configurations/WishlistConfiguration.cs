using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("Wishlist");
            builder.Property(e => e.Id).HasColumnType("int");

            builder.HasOne<Product>()
             .WithMany(e => e.Wishlists)
             .HasForeignKey(e => e.ProductId)
             .IsRequired();
        }
    }
}
