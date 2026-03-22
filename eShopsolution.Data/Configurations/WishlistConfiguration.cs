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
            builder.Property(e => e.Id)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(w => w.ProductId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(w => w.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(w => w.Product)
                .WithMany(p => p.Wishlists)
                .HasForeignKey(w => w.ProductId)
                .OnDelete(DeleteBehavior.Cascade) 
                .IsRequired();
        }
    }

}
