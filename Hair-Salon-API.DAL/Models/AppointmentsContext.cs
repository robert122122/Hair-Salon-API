using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hair_Salon_API.DAL.Models
{
    public partial class AppointmentsContext : DbContext
    {
        public AppointmentsContext()
        {
        }

        public AppointmentsContext(DbContextOptions<AppointmentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Barber> Barbers { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Salon> Salons { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceBarber> ServiceBarbers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = Appointments;TrustServerCertificate = True; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);
            });

            modelBuilder.Entity<Barber>(entity =>
            {
                entity.ToTable("Barber");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.Salon)
                    .WithMany(p => p.Barbers)
                    .HasForeignKey(d => d.SalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Barber_Salon");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingChanged).HasColumnType("datetime");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Barber)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.BarberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Barber");

                entity.HasOne(d => d.Salon)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Salon");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Service");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_User");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.HasOne(d => d.Salon)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.SalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Salon");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_User");
            });

            modelBuilder.Entity<Salon>(entity =>
            {
                entity.ToTable("Salon");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Salons)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Salon_Address");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Cost).HasColumnType("smallmoney");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ServiceName).HasMaxLength(50);

                entity.HasOne(d => d.Salon)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.SalonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Salon");
            });

            modelBuilder.Entity<ServiceBarber>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ServiceBarber");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Barber)
                    .WithMany()
                    .HasForeignKey(d => d.BarberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceBarber_Barber");

                entity.HasOne(d => d.Service)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceBarber_Service");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
