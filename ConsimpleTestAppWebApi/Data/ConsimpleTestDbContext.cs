using System;
using System.Collections.Generic;
using ConsimpleTestAppWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestAppWebApi.Data;

public partial class ConsimpleTestDbContext : DbContext
{
    public ConsimpleTestDbContext()
    {
    }

    public ConsimpleTestDbContext(DbContextOptions<ConsimpleTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseProduct> PurchaseProducts { get; set; }

    public virtual DbSet<Сategory> Сategories { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ConsimpleTestDB;Trusted_Connection=True;TrustServerCertificate=True;");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Customer_Id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Products_Id");

            entity.HasOne(d => d.Сategory).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_To_Сategory");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Purchases_Id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Purchases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Purchases_To_Customer");
        });

        modelBuilder.Entity<PurchaseProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PurchaseProducts_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseProducts_To_Products");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseProducts_To_Purchases");
        });

        modelBuilder.Entity<Сategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Сategory_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
