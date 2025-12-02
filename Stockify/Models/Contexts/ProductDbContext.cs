using System;
using Microsoft.EntityFrameworkCore;
using static Stockify.Models.Product;

namespace Stockify.Models
{
	public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductId")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CostPerUnitWeight)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CostPerUnit)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.WeightPerUnit)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CostPer100Sqft)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.WeightPer100Sqft)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime");
            });
        }
    }
}

