using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.Property(e => e.Id).HasColumnType("int");

            builder.HasOne(e => e.Product)
            .WithMany(e => e.OrderDetails)
            .HasForeignKey(e => e.ProductId)
            .IsRequired();

            builder.HasOne(e => e.Order)
          .WithMany(e => e.OrderDetails)
          .HasForeignKey(e => e.OrderId)
          .IsRequired();
        }
    }
}
