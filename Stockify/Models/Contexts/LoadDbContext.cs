using System;
using Microsoft.EntityFrameworkCore;

namespace Stockify.Models
{
    public class LoadDbContext : DbContext
    {
        public LoadDbContext(DbContextOptions<LoadDbContext> options) : base(options)
        {
        }

        public DbSet<Load> Loads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Load>(entity =>
            {
                entity.ToTable("Loads");

                entity.Property(e => e.LoadId)
                    .HasColumnName("LoadId")
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

                entity.Property(e => e.LoadGroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleNo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime");
            });
        }
    }
}

