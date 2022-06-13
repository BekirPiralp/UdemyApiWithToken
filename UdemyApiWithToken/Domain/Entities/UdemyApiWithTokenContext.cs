using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UdemyApiWithToken.Domain.Model;

namespace UdemyApiWithToken.Domain.Entities
{
    public partial class UdemyApiWithTokenContext : DbContext
    {
        public UdemyApiWithTokenContext() : base()
        {
        }

        public UdemyApiWithTokenContext(DbContextOptions<UdemyApiWithTokenContext> options)
            : base(options)
        {
        }

        //public UdemyApiWithTokenContext(DbContextOptions options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Product> Products { get; set; } //= null!;
        public virtual DbSet<User> Users { get; set; }// = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(WebApplication.CreateBuilder().Configuration.GetConnectionString("Varsayilan"));
            }
        }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Entity<Product>(entity =>
        //            {
        //                entity.ToTable("Product");

        //                entity.Property(e => e.Category).HasMaxLength(50);

        //                entity.Property(e => e.Name).HasMaxLength(50);

        //                entity.Property(e => e.Price).HasColumnType("money");
        //            });

        //            modelBuilder.Entity<User>(entity =>
        //            {
        //                entity.ToTable("User");

        //                entity.Property(e => e.Email).HasMaxLength(100);

        //                entity.Property(e => e.Name).HasMaxLength(50);

        //                entity.Property(e => e.Password).HasMaxLength(8);

        //                entity.Property(e => e.RefreshToken).HasMaxLength(500);

        //                entity.Property(e => e.RefreshTokenEndDate).HasColumnType("datetime");

        //                entity.Property(e => e.SurName).HasMaxLength(50);
        //            });

        //            OnModelCreatingPartial(modelBuilder);
        //        }

    }
}
