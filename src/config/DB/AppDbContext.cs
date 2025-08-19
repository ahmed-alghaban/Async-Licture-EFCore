using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src.models;

namespace ProductAppAsync.src.config.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(product => product.ProductId);
                entity.Property(product => product.Name).HasMaxLength(100).IsRequired();
                entity.Property(product => product.Description).HasMaxLength(500).IsRequired();
                entity.Property(product => product.Price).IsRequired();

                entity.HasOne(product => product.AssociatedCategory)
                .WithMany(category => category.AssociatedProducts)
                .HasForeignKey(product => product.CategoryId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(category => category.CategoryId);
                entity.Property(category => category.Name).HasMaxLength(100).IsRequired();
                entity.HasIndex(category => category.Name).IsUnique();
                entity.Property(category => category.Description).HasMaxLength(500).IsRequired();

                // entity.HasMany(category => category.AssociatedProducts)
                // .WithOne(product => product.AssociatedCategory)
                // .HasForeignKey(product => product.CategoryId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.UserId);
                entity.Property(user => user.Email).HasMaxLength(100).IsRequired();
                entity.HasIndex(user => user.Email).IsUnique();
                entity.Property(user => user.Password).HasMaxLength(100).IsRequired();

                entity.HasOne(user => user.profile)
                .WithOne(profile => profile.User)
                .HasForeignKey<ProfileModel>(profile => profile.UserId);
            });

            modelBuilder.Entity<ProfileModel>(entity =>
            {
                entity.HasKey(profile => profile.ProfileId);
                entity.Property(profile => profile.Name).HasMaxLength(100).IsRequired();
                entity.Property(profile => profile.Address).HasMaxLength(500).IsRequired();
                entity.Property(profile => profile.PhoneNumber).HasMaxLength(100).IsRequired();
             }
            );
        }
    }
}