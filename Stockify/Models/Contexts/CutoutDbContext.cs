using System;
using Microsoft.EntityFrameworkCore;

namespace Stockify.Models
{
    public class CutoutDbContext : DbContext
    {
        public CutoutDbContext(DbContextOptions<CutoutDbContext> options) : base(options)
        {
        }

        public DbSet<Cutout> Cutouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cutout>(entity =>
            {
                entity.ToTable("Cutouts");

                entity.Property(e => e.CutoutId)
                    .HasColumnName("CutoutId")
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

