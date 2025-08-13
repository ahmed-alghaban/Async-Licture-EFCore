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
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(category => category.CategoryId);
                entity.Property(category => category.Name).HasMaxLength(100).IsRequired();
                entity.HasIndex(category => category.Name).IsUnique();
                entity.Property(category => category.Description).HasMaxLength(500).IsRequired();
            });
        }
    }
}