using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Customer_Api.Models;

public partial class MicroserviceContext : DbContext
{
    public MicroserviceContext()
    {
    }

    public MicroserviceContext(DbContextOptions<MicroserviceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerTable> CustomerTables { get; set; }

    public virtual DbSet<ProductsTable> ProductsTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=IN3281021W2;database=Microservice;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerTable>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("CustomerTable");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductsTable>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("ProductsTable");

            entity.Property(e => e.ProductDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
