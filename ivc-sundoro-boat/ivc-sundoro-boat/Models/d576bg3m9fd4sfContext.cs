using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ivc_sundoro_boat.Models
{
    public partial class d576bg3m9fd4sfContext : DbContext
    {
        IConfiguration _configuration;
        public d576bg3m9fd4sfContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public d576bg3m9fd4sfContext(DbContextOptions<d576bg3m9fd4sfContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<CustomerRoute> CustomerRoutes { get; set; } = null!;
        public virtual DbSet<DataCustomer> DataCustomers { get; set; } = null!;
        public virtual DbSet<DataRoute> DataRoutes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("production"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<CustomerRoute>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("Customer_Route_pkey");

                entity.ToTable("Customer_Route");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CustUuid).HasColumnName("cust_uuid");

                entity.Property(e => e.RouteUuid).HasColumnName("route_uuid");
            });

            modelBuilder.Entity<DataCustomer>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("Data_Customer_pkey");

                entity.ToTable("Data_Customer");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.BoatPrice).HasColumnName("boat_price");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CustName)
                    .HasMaxLength(200)
                    .HasColumnName("cust_name");

                entity.Property(e => e.DateIvc).HasColumnName("date_ivc");

                entity.Property(e => e.IsPph).HasColumnName("is_pph");

                entity.Property(e => e.Necessity)
                    .HasMaxLength(200)
                    .HasColumnName("necessity");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note");

                entity.Property(e => e.NumberIvc)
                    .HasMaxLength(100)
                    .HasColumnName("number_ivc");

                entity.Property(e => e.PphValue).HasColumnName("pph_value");

                entity.Property(e => e.RentDate).HasColumnName("rent_date");

                entity.Property(e => e.RentTime).HasColumnName("rent_time");
            });

            modelBuilder.Entity<DataRoute>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("Data_Route_pkey");

                entity.ToTable("Data_Route");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.RouteCode)
                    .HasMaxLength(10)
                    .HasColumnName("route_code");

                entity.Property(e => e.RouteName)
                    .HasMaxLength(150)
                    .HasColumnName("route_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
