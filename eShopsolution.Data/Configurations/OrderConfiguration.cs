using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(e => e.Id).HasColumnType("int");

            builder.HasOne(e => e.RoomAndTable)
            .WithMany(e => e.Orders)
            .HasForeignKey(e => e.RoomAndTableId)
            .IsRequired();
        }
    }
}
