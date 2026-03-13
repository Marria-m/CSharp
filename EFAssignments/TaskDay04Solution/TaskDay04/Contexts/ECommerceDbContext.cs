using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDay04.Models;

namespace TaskDay04.Contexts
{
    internal class ECommerceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=ECommerceDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.ToTable("Categories");
                c.HasKey(c => c.Id);
                c.Property(c => c.Name)
                 .IsRequired(true)
                 .HasMaxLength(100);

                // Category (one), Products (many)
                c.HasMany(c => c.Products)
                 .WithOne(p => p.Category)
                 .HasForeignKey(p => p.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Products");
                p.HasKey(p => p.Id);
                p.Property(p => p.Name)
                 .IsRequired(true)
                 .HasMaxLength(150);
                p.Property(p => p.Price)
                 .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<Customer>(c =>
            {
                c.ToTable("Customers");
                c.HasKey(c => c.Id);
                c.Property(c => c.Name)
                 .IsRequired(true)
                 .HasMaxLength(100);
                c.Property(c => c.Email)
                 .IsRequired(true)
                 .HasMaxLength(200);

                // Customer (one), Orders (many)
                c.HasMany(c => c.Orders)
                 .WithOne(o => o.Customer)
                 .HasForeignKey(o => o.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.ToTable("Orders");
                o.HasKey(o => o.Id);
                o.Property(o => o.OrderDate)
                 .IsRequired(true);
            });

            modelBuilder.Entity<OrderDetail>(od =>
            {
                od.ToTable("OrderDetails");

                // Composite PK
                od.HasKey(od => new { od.OrderId, od.ProductId });

                od.Property(od => od.Quantity)
                  .IsRequired(true);

                // side 1 -> OrderDetail ans Order
                od.HasOne(od => od.Order)
                  .WithMany(o => o.OrderDetails)
                  .HasForeignKey(od => od.OrderId);

                // side 2 -> OrderDetail and Product
                od.HasOne(od => od.Product)
                  .WithMany(p => p.OrderDetails)
                  .HasForeignKey(od => od.ProductId);
            });
        }
    }
}
