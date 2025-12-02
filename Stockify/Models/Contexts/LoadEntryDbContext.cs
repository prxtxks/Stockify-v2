using System;
using Microsoft.EntityFrameworkCore;

namespace Stockify.Models
{
    public class LoadEntryDbContext : DbContext
    {
        public LoadEntryDbContext(DbContextOptions<LoadEntryDbContext> options) : base(options)
        {
        }

        public DbSet<LoadEntry> LoadEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoadEntry>(entity =>
            {
                entity.ToTable("Load Entries");

                entity.Property(e => e.LoadEntryId)
                    .HasColumnName("LoadEntryId")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.LoadId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
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

