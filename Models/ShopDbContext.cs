using System;
using System.Collections.Generic;
using _1_2.Models;
using Microsoft.EntityFrameworkCore;

namespace _1_2;

public partial class ShopDbContext : DbContext
{
    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Podcategory> Podcategories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsOrder> ProductsOrders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<StocksItem> StocksItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=shop_db;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriesName).HasColumnName("categories_name");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Productions_pkey");

            entity.ToTable("manufacturers");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Productions_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.ManufacturerName).HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_id_user_fkey");
        });

        modelBuilder.Entity<Podcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("podcategories_pkey");

            entity.ToTable("podcategories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PodcategoriesName).HasColumnName("podcategories_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Compound).HasColumnName("compound");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCategorie).HasColumnName("id_categorie");
            entity.Property(e => e.IdManufacturers).HasColumnName("id_manufacturers");
            entity.Property(e => e.IdPodcategorie).HasColumnName("id_podcategorie");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdCategorieNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategorie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_id_categorie_fkey");

            entity.HasOne(d => d.IdManufacturersNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdManufacturers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_id_manufacturers_fkey");

            entity.HasOne(d => d.IdPodcategorieNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdPodcategorie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_id_podcategorie_fkey");
        });

        modelBuilder.Entity<ProductsOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_order_pkey");

            entity.ToTable("products_order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdStockItem).HasColumnName("id_stock_item");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ProductsOrders)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_order_id_order_fkey");

            entity.HasOne(d => d.IdStockItemNavigation).WithMany(p => p.ProductsOrders)
                .HasForeignKey(d => d.IdStockItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_order_id_stock_item_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sizes_pkey");

            entity.ToTable("sizes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Size1).HasColumnName("size");
        });

        modelBuilder.Entity<StocksItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stocks_items_pkey");

            entity.ToTable("stocks_items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdSize).HasColumnName("id_size");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.StocksItems)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stocks_items_id_product_fkey");

            entity.HasOne(d => d.IdSizeNavigation).WithMany(p => p.StocksItems)
                .HasForeignKey(d => d.IdSize)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stocks_items_id_size_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('\"Users_id_seq\"'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.FirstName).HasColumnName("First name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
