using eShopSolution.Data.Emtyties;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Data;

namespace eShopsolution.Data.EF
{
    public class EShopDbContext : IdentityDbContext<ApplicationUser>
    {
            

        public EShopDbContext( DbContextOptions options) : base(options)
        {   
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        



        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ID).HasColumnType("int");

            });
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

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }

    }
}
