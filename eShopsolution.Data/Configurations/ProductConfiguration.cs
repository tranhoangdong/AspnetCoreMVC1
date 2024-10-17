using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(e => e.Id).HasColumnType("int");

            builder.HasOne(e => e.Category)
         .WithMany(e => e.Products)
         .HasForeignKey(e => e.CategoryId)
         .IsRequired();
        }
    }
}
