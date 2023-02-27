using System;
using System.Collections.Generic;
using InventoryManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.EF.Models;

public partial class InventoryManagementContext : DbContext
{
    public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
        : base(options)
    {
    }

    public  DbSet<Category> Categories { get; set; }

    public  DbSet<Customer> Customers { get; set; }

    public  DbSet<Inventory> Inventories { get; set; }

    public  DbSet<Order> Orders { get; set; }

    public  DbSet<OrderItem> OrderItems { get; set; }

    public  DbSet<Product> Products { get; set; }

    public  DbSet<Supplier> Suppliers { get; set; }

    public  DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FBCF662C9");

            entity.ToTable("Category");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id") ;
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FBC6EFB5C");

            entity.ToTable("customer");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__inventor__3213E83F13658D1B");

            entity.ToTable("inventory");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.MinStockLevel).HasColumnName("min_stock_level");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.StockLevel).HasColumnName("stock_level");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inventory__produ__5CD6CB2B");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order___3213E83FBBC0C596");

            entity.ToTable("order_");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("order_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order___customer__5629CD9C");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__order_it__022945F640B3A7D5");

            entity.ToTable("order_item");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order_ite__order__59063A47");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order_ite__produ__59FA5E80");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83F7687ED29");

            entity.ToTable("product");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product__categor__4BAC3F29");

            entity.HasMany(d => d.Suppliers).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSupplier",
                    r => r.HasOne<Supplier>().WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__product_s__suppl__5165187F"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__product_s__produ__5070F446"),
                    j =>
                    {
                        j.HasKey("ProductId", "SupplierId").HasName("PK__product___D1EC24BB137521C1");
                        j.ToTable("product_supplier");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("SupplierId").HasColumnName("supplier_id");
                    });
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__3213E83FB3628338");

            entity.ToTable("supplier");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F4BFB4D05");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164CAB7008D").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__users__F3DBC57233F7AD4E").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
