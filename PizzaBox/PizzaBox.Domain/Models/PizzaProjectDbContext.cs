using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Domain.Models
{
    public partial class PizzaProjectDbContext : DbContext
    {
        public PizzaProjectDbContext()
        {
        }

        public PizzaProjectDbContext(DbContextOptions<PizzaProjectDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CxOrder> CxOrder { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<TempCustomerOrder> TempCustomerOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Code romoved for security 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("fname")
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("lname")
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CxOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__CxOrder__C3905BAF03E232FA");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustId).HasColumnName("Cust_Id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.CxOrder)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CxOrder__Cust_Id__5070F446");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.CxOrder)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CxOrder__Store_I__4F7CD00D");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.PizzaId)
                    .HasColumnName("PizzaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Crust)
                    .IsRequired()
                    .HasColumnName("crust")
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Toppings).HasColumnName("toppings");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza__OrderID__534D60F1");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StoreLocation)
                    .IsRequired()
                    .HasColumnName("storeLocation")
                    .IsUnicode(false);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasColumnName("storeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TempCustomerOrder>(entity =>
            {
                entity.HasKey(e => new { e.CustId, e.PizzaId })
                    .HasName("PK__tempCust__C4283B84C06E1A34");

                entity.ToTable("tempCustomerOrder");

                entity.Property(e => e.Crust)
                    .IsRequired()
                    .HasColumnName("crust")
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.TempCustomerOrder)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tempCusto__CustI__6383C8BA");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.TempCustomerOrder)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tempCusto__Store__6477ECF3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
