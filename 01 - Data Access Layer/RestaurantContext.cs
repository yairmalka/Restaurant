using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Restaurant;

public partial class RestaurantContext : DbContext
{
    public RestaurantContext()
    {
    }

    public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlExpress;DataBase=Restaurant;Trusted_connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Categrories");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerEmail).HasMaxLength(200);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(15);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuItemId);

            entity.ToTable("Menu");

            entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.MenuItemDescription).HasMaxLength(500);
            entity.Property(e => e.MenuItemName).HasMaxLength(200);

            entity.HasOne(d => d.Category).WithMany(p => p.Menus)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Menu_Categories");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderType).HasMaxLength(1);
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Table).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK_Orders_Tables");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.SpecialRequests).HasMaxLength(1);

            entity.HasOne(d => d.MenuItem).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Menu");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Orders");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ReviewData).HasMaxLength(500);
            entity.Property(e => e.ReviewDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Reviews_Customers");

            entity.HasOne(d => d.Order).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Reviews_Orders");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.Property(e => e.TableId).HasColumnName("TableID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
