using System;
using Microsoft.EntityFrameworkCore;

namespace Stockify.Models
{
    public class JobWorkEntryDbContext : DbContext
    {
        public JobWorkEntryDbContext(DbContextOptions<JobWorkEntryDbContext> options) : base(options)
        {
        }

        public DbSet<JobWorkEntry> JobWorkEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobWorkEntry>(entity =>
            {
                entity.ToTable("JobWork Entries");

                entity.Property(e => e.JobWorkEntryId)
                    .HasColumnName("JobWorkEntryId")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.JobWorkId)
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

