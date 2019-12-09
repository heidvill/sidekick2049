using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SideKickDLL
{
    public partial class PelaajadbContext : DbContext
    {
        public PelaajadbContext()
        {
        }

        public PelaajadbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Tilasto> Tilasto { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("server=localhost;database=Pelaajadb;trusted_connection=true");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tilasto>(entity =>
            {
                entity.ToTable("tilasto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aika)
                    .HasColumnName("aika")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nimi)
                    .IsRequired()
                    .HasColumnName("nimi")
                    .HasMaxLength(255);

                entity.Property(e => e.Taso).HasColumnName("taso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
