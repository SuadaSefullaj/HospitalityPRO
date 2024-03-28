using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HumanResourceProject.Models
{
    public partial class HospitalityPRO_DbContext : DbContext
    {
        public HospitalityPRO_DbContext()
        {
        }

        public HospitalityPRO_DbContext(DbContextOptions<HospitalityPRO_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BrowsingDatum> BrowsingData { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ExtraService> ExtraServices { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<ReservationService> ReservationServices { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=HospitalityPRO_Db;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrowsingDatum>(entity =>
            {
                entity.HasKey(e => e.BrowsingId)
                    .HasName("PK__Browsing__6FAAE202C85348B8");

                entity.ToTable("Browsing_Data");

                entity.Property(e => e.BrowsingId).HasColumnName("Browsing_Id");

                entity.Property(e => e.ActionType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Action_type");

                entity.Property(e => e.ReservationDetails)
                    .HasMaxLength(225)
                    .IsUnicode(false)
                    .HasColumnName("Reservation_Details");

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.Email, "UQ__Client__A9D10534F44FEE9E")
                    .IsUnique();

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.Birth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExtraService>(entity =>
            {
                entity.HasKey(e => e.ServicesId)
                    .HasName("PK__Extra_Se__A74BF874192B162C");

                entity.ToTable("Extra_Services");

                entity.Property(e => e.ServicesId).HasColumnName("Services_Id");

                entity.Property(e => e.Description)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.HotelId)
                    .ValueGeneratedNever()
                    .HasColumnName("Hotel_Id");

                entity.Property(e => e.CheckinTime).HasColumnType("datetime");

                entity.Property(e => e.CheckoutTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Owner)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.NotificationId).HasColumnName("Notification_Id");

                entity.Property(e => e.IsRead).HasColumnName("isRead");

                entity.Property(e => e.ReceiverClientId).HasColumnName("Receiver_Client_Id");

                entity.Property(e => e.ReservationId).HasColumnName("Reservation_Id");

                entity.Property(e => e.SenderClientId).HasColumnName("Sender_Client_Id");

                entity.HasOne(d => d.ReceiverClient)
                    .WithMany(p => p.NotificationReceiverClients)
                    .HasForeignKey(d => d.ReceiverClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Recei__3A81B327");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Reser__38996AB5");

                entity.HasOne(d => d.SenderClient)
                    .WithMany(p => p.NotificationSenderClients)
                    .HasForeignKey(d => d.SenderClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Sende__398D8EEE");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.Property(e => e.ReservationId).HasColumnName("Reservation_Id");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("date")
                    .HasColumnName("Check_in_date");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("date")
                    .HasColumnName("Check_out_date");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.ReservationStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Reservation_Status");

                entity.Property(e => e.RoomNumber).HasColumnName("Room_Number");

                entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__Clien__2F10007B");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__Room___300424B4");
            });

            modelBuilder.Entity<ReservationService>(entity =>
            {
                entity.HasKey(e => e.ReservationServicesId)
                    .HasName("PK__Reservat__89ECE053C95D6CD4");

                entity.ToTable("Reservation_Services");

                entity.Property(e => e.ReservationServicesId).HasColumnName("ReservationServices_Id");

                entity.Property(e => e.ReservationId).HasColumnName("Reservation_Id");

                entity.Property(e => e.ServicesId).HasColumnName("Services_Id");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.ReservationServices)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__Reser__34C8D9D1");

                entity.HasOne(d => d.Services)
                    .WithMany(p => p.ReservationServices)
                    .HasForeignKey(d => d.ServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__Servi__35BCFE0A");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomNumber)
                    .HasName("PK__Room__353A906EDA5F5670");

                entity.ToTable("Room");

                entity.Property(e => e.RoomNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("Room_Number");

                entity.Property(e => e.Availability)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HotelId).HasColumnName("Hotel_Id");

                entity.Property(e => e.TypeId).HasColumnName("Type_Id");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__Hotel_Id__2B3F6F97");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__Type_Id__2C3393D0");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__Room_Typ__FE90DD9EB4C0A9EC");

                entity.ToTable("Room_Type");

                entity.Property(e => e.TypeId).HasColumnName("Type_Id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId)
                    .HasName("PK_RefreshTokens");

                entity.ToTable("RefreshTokens");

                entity.Property(e => e.TokenId).HasColumnName("TokenId");

                entity.Property(e => e.Token)
                    .IsRequired();

                entity.Property(e => e.Created)
                    .IsRequired();

                entity.Property(e => e.Expires)
                    .IsRequired();

                // Configure relationship
                entity.HasOne(rt => rt.Client)
                      .WithMany(c => c.RefreshTokens)
                      .HasForeignKey(rt => rt.ClientId)
                      .IsRequired();
            });
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
