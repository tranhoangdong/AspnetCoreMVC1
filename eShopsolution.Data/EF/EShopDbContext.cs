using eShopSolution.Data.Emtyties;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Data;

namespace eShopsolution.Data.EF
{
    public class EShopDbContext : IdentityDbContext<User, Roles, int>
    {
            

        public EShopDbContext( DbContextOptions options) : base(options)
        {   
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ID).HasColumnType("int");

            });
            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.ID).HasColumnType("int");

            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnType("int");

            });
            modelBuilder.Entity<Image>()
              .HasOne(e => e.product)
              .WithMany(e => e.Images)
              .HasForeignKey(e => e.ProductId)
              .IsRequired();
             modelBuilder.Entity<Product>()
              .HasOne(e => e.Category)
              .WithMany(e => e.Products)
              .HasForeignKey(e => e.CategoryId)
              .IsRequired();
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
