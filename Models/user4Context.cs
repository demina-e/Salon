using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalonApi.Models
{
    public partial class user4Context : DbContext
    {
        public user4Context()
        {
        }

        public user4Context(DbContextOptions<user4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AttachedProduct> AttachedProduct { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientService> ClientService { get; set; }
        public virtual DbSet<DocumentByService> DocumentByService { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServicePhoto> ServicePhoto { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TagOfClient> TagOfClient { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=user4;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttachedProduct>(entity =>
            {
                entity.HasKey(e => new { e.MainProductId, e.AttachedProductId });

                entity.Property(e => e.MainProductId).HasColumnName("MainProductID");

                entity.Property(e => e.AttachedProductId).HasColumnName("AttachedProductID");

                entity.HasOne(d => d.AttachedProductNavigation)
                    .WithMany(p => p.AttachedProductAttachedProductNavigation)
                    .HasForeignKey(d => d.AttachedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachedProduct_Product1");

                entity.HasOne(d => d.MainProduct)
                    .WithMany(p => p.AttachedProductMainProduct)
                    .HasForeignKey(d => d.MainProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttachedProduct_Product");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhotoPath).HasMaxLength(1000);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.GenderCodeNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.GenderCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Gender");
            });

            modelBuilder.Entity<ClientService>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientService)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Client");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ClientService)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientService_Service");
            });

            modelBuilder.Entity<DocumentByService>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientServiceId).HasColumnName("ClientServiceID");

                entity.Property(e => e.DocumentPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ClientService)
                    .WithMany(p => p.DocumentByService)
                    .HasForeignKey(d => d.ClientServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentByService_ClientService");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.MainImagePath).HasMaxLength(1000);

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_Product_Manufacturer");
            });

            modelBuilder.Entity<ProductPhoto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPhoto)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPhoto_Product");
            });

            modelBuilder.Entity<ProductSale>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientServiceId).HasColumnName("ClientServiceID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.HasOne(d => d.ClientService)
                    .WithMany(p => p.ProductSale)
                    .HasForeignKey(d => d.ClientServiceId)
                    .HasConstraintName("FK_ProductSale_ClientService");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSale)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductSale_Product");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.MainImagePath).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ServicePhoto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PhotoPath)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServicePhoto)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePhoto_Service");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TagOfClient>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TagId });

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TagOfClient)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagOfClient_Client");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagOfClient)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagOfClient_Tag");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
