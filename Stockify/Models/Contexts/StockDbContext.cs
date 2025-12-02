using System;
using Microsoft.EntityFrameworkCore;

namespace Stockify.Models
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stocks");

                entity.Property(e => e.StockId)
                    .HasColumnName("StockId")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoadGroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Height)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Width)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime");
            });
        }
    }
}

