﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorDDL.Shared.Models
{
    public partial class myTestDBContext : DbContext
    {
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Country> Country { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myTestDB;Data Source=ANKIT-HP\SQLEXPRESS;");
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=myTestDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Cities__CountryI__25869641");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
