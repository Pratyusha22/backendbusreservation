using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusReservation.Models
{
    public partial class BusReservationContext : DbContext
    {
        public BusReservationContext()
        {
        }

        public BusReservationContext(DbContextOptions<BusReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPassengerDetails> TblPassengerDetails { get; set; }
        public virtual DbSet<Tbladmin> Tbladmin { get; set; }
        public virtual DbSet<Tblbooking> Tblbooking { get; set; }
        public virtual DbSet<Tblbus> Tblbus { get; set; }
        public virtual DbSet<Tblbusschedule> Tblbusschedule { get; set; }
        public virtual DbSet<Tbldriver> Tbldriver { get; set; }
        public virtual DbSet<Tblregcustomer> Tblregcustomer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HH0PVJC;Database=BusReservation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPassengerDetails>(entity =>
            {
                entity.HasKey(e => e.PassengerId)
                    .HasName("PK__tblPasse__88915FB0181EE4A6");

                entity.ToTable("tblPassengerDetails");

                entity.Property(e => e.BusId).HasColumnName("busId");

                entity.Property(e => e.Contact)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.TblPassengerDetails)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK__tblPassen__busId__5629CD9C");
            });

            modelBuilder.Entity<Tbladmin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__tbladmin__AD0500A686C37912");

                entity.ToTable("tbladmin");

                entity.Property(e => e.AdminId)
                    .HasColumnName("adminId")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailId)
                    .HasColumnName("emailId")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("fullName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userPassword")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblbooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__tblbooki__C6D03BCD3FB1DF17");

                entity.ToTable("tblbooking");

                entity.Property(e => e.BookingId).HasColumnName("bookingId");

                entity.Property(e => e.BookingStatus)
                    .HasColumnName("booking_status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NumberOfSeats).HasColumnName("number_of_seats");

                entity.Property(e => e.ScheduleId).HasColumnName("scheduleId");

                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Tblbooking)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK__tblbookin__sched__4D94879B");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.Tblbooking)
                    .HasForeignKey(d => d.UserName)
                    .HasConstraintName("FK__tblbookin__UserN__4CA06362");
            });

            modelBuilder.Entity<Tblbus>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .HasName("PK__tblbus__A443D25D4A0B0674");

                entity.ToTable("tblbus");

                entity.Property(e => e.BusId)
                    .HasColumnName("busId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusNumber)
                    .IsRequired()
                    .HasColumnName("busNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BusType)
                    .HasColumnName("busType")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Capacity).HasColumnName("capacity");
            });

            modelBuilder.Entity<Tblbusschedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__tblbussc__A532EDD4FFAC68FE");

                entity.ToTable("tblbusschedule");

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("scheduleId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArrivalTime)
                    .HasColumnName("arrival_time")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BusId).HasColumnName("busId");

                entity.Property(e => e.DepartureTime)
                    .HasColumnName("departure_time")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasColumnName("destination")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FareAmount).HasColumnName("fare_amount");

                entity.Property(e => e.ScheduledDate)
                    .HasColumnName("scheduled_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Startingpt)
                    .IsRequired()
                    .HasColumnName("startingpt")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Tblbusschedule)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK__tblbussch__busId__3E52440B");
            });

            modelBuilder.Entity<Tbldriver>(entity =>
            {
                entity.HasKey(e => e.DriverId)
                    .HasName("PK__tbldrive__F1532DF200BDC902");

                entity.ToTable("tbldriver");

                entity.Property(e => e.DriverId)
                    .HasColumnName("driverId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusId).HasColumnName("busId");

                entity.Property(e => e.DriverContact)
                    .HasColumnName("driverContact")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasColumnName("driverName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Tbldriver)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK__tbldriver__busId__3B75D760");
            });

            modelBuilder.Entity<Tblregcustomer>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__tblregcu__C9F28457C544D34E");

                entity.ToTable("tblregcustomer");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAge).HasColumnName("customerAge");

                entity.Property(e => e.CustomerContact)
                    .IsRequired()
                    .HasColumnName("customerContact")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customerEmail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerGender)
                    .HasColumnName("customerGender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customerName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WalletAmount).HasColumnName("Wallet_amount");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
