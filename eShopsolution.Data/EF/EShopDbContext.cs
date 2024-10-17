using eShopSolution.Data.Configurations;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.Reflection.Emit;

namespace eShopsolution.Data.EF
{
    public class EShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public EShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<RoomAndTable> RoomAndTables { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());

            // TODO: refactor
            builder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.ID).HasColumnType("int");

            });
            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnType("int");

            });
            builder.Entity<RoomAndTable>(entity =>
            {
                entity.ToTable("RoomAndTable");

                entity.Property(e => e.Id).HasColumnType("int");

            });
            builder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnType("int");

            });

            builder.Entity<Image>()
              .HasOne(e => e.product)
              .WithMany(e => e.Images)
              .HasForeignKey(e => e.ProductId)
              .IsRequired();

            builder.Entity<Product>()
             .HasOne(e => e.Category)
             .WithMany(e => e.Products)
             .HasForeignKey(e => e.CategoryId)
             .IsRequired();

            builder.Entity<OrderDetail>()
            .HasOne(e => e.Product)
            .WithMany(e => e.OrderDetails)
            .HasForeignKey(e => e.ProductId)
            .IsRequired();

            builder.Entity<OrderDetail>()
           .HasOne(e => e.Order)
           .WithMany(e => e.OrderDetails)
           .HasForeignKey(e => e.OrderId)
           .IsRequired();

            builder.Entity<Order>()
           .HasOne(e => e.RoomAndTable)
           .WithMany(e => e.Orders)
           .HasForeignKey(e => e.RoomAndTableId)
           .IsRequired();

            builder.Entity<RoomAndTable>()
             .HasOne(e => e.Status)
             .WithMany(e => e.RoomAndTables)
             .HasForeignKey(e => e.StatusId)
             .IsRequired();

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("User", "Identity");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("Role", "Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", "Identity");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });
        }
    }
}
