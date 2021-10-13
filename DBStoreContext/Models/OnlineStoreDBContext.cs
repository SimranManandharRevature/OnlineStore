using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModelsLayer.EFModels;

#nullable disable

namespace DBStoreContext.Models
{
  public partial class OnlineStoreDBContext : DbContext
  {
    public OnlineStoreDBContext()
    {
    }

    public OnlineStoreDBContext(DbContextOptions<OnlineStoreDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductOrder> ProductOrders { get; set; }
    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseSqlServer("Server=08162021dotnetuta.database.windows.net;Database=OnlineStoreDB;User Id=sqladmin;Password=Password12345;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Customer>(entity =>
      {
        entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);
      });

      modelBuilder.Entity<Order>(entity =>
      {
        entity.Property(e => e.OrderDate)
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("(getdate())");

        entity.HasOne(d => d.Customer)
                  .WithMany(p => p.Orders)
                  .HasForeignKey(d => d.CustomerId)
                  .HasConstraintName("FK__Orders__Customer__00200768");
      });

      modelBuilder.Entity<Product>(entity =>
      {
        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);

        entity.Property(e => e.Picture)
                  .IsRequired()
                  .HasMaxLength(8000)
                  .IsUnicode(false);

        entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

        entity.HasOne(d => d.Store)
                  .WithMany(p => p.Products)
                  .HasForeignKey(d => d.StoreId)
                  .HasConstraintName("FK__Products__StoreI__7D439ABD");
      });

      modelBuilder.Entity<ProductOrder>(entity =>
      {
        entity.ToTable("ProductOrder");

        entity.HasOne(d => d.Order)
                  .WithMany(p => p.ProductOrders)
                  .HasForeignKey(d => d.OrderId)
                  .HasConstraintName("FK__ProductOr__Order__04E4BC85");

        entity.HasOne(d => d.Product)
                  .WithMany(p => p.ProductOrders)
                  .HasForeignKey(d => d.ProductId)
                  .HasConstraintName("FK__ProductOr__Produ__03F0984C");
      });

      modelBuilder.Entity<Store>(entity =>
      {
        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);

        entity.Property(e => e.Picture)
                  .IsRequired()
                  .HasMaxLength(8000)
                  .IsUnicode(false);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
