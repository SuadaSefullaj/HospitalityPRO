﻿// <auto-generated />
using System;
using HumanResourceProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(HospitalityPRO_DbContext))]
    partial class HospitalityPRO_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.RefreshToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TokenId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenId"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TokenId")
                        .HasName("PK_RefreshTokens");

                    b.HasIndex("ClientId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.BrowsingDatum", b =>
                {
                    b.Property<int>("BrowsingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Browsing_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrowsingId"), 1L, 1);

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Action_type");

                    b.Property<string>("ReservationDetails")
                        .IsRequired()
                        .HasMaxLength(225)
                        .IsUnicode(false)
                        .HasColumnType("varchar(225)")
                        .HasColumnName("Reservation_Details");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime");

                    b.HasKey("BrowsingId")
                        .HasName("PK__Browsing__6FAAE202C85348B8");

                    b.ToTable("Browsing_Data", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Client_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<DateTime>("Birth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Phone_Number");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ClientId");

                    b.HasIndex(new[] { "Email" }, "UQ__Client__A9D10534F44FEE9E")
                        .IsUnique();

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.ExtraService", b =>
                {
                    b.Property<int>("ServicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Services_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicesId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(225)
                        .IsUnicode(false)
                        .HasColumnType("varchar(225)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ServicesId")
                        .HasName("PK__Extra_Se__A74BF874192B162C");

                    b.ToTable("Extra_Services", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("Hotel_Id");

                    b.Property<DateTime>("CheckinTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CheckoutTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Phone_Number");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("HotelId");

                    b.ToTable("Hotel", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Notification_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit")
                        .HasColumnName("isRead");

                    b.Property<int>("ReceiverClientId")
                        .HasColumnType("int")
                        .HasColumnName("Receiver_Client_Id");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("Reservation_Id");

                    b.Property<int>("SenderClientId")
                        .HasColumnType("int")
                        .HasColumnName("Sender_Client_Id");

                    b.HasKey("NotificationId");

                    b.HasIndex("ReceiverClientId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("SenderClientId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Reservation_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("date")
                        .HasColumnName("Check_in_date");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("date")
                        .HasColumnName("Check_out_date");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("Client_Id");

                    b.Property<string>("ReservationStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Reservation_Status");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int")
                        .HasColumnName("Room_Number");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float")
                        .HasColumnName("Total_Price");

                    b.HasKey("ReservationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("RoomNumber");

                    b.ToTable("Reservation", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.ReservationService", b =>
                {
                    b.Property<int>("ReservationServicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReservationServices_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationServicesId"), 1L, 1);

                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("Reservation_Id");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int")
                        .HasColumnName("Services_Id");

                    b.HasKey("ReservationServicesId")
                        .HasName("PK__Reservat__89ECE053C95D6CD4");

                    b.HasIndex("ReservationId");

                    b.HasIndex("ServicesId");

                    b.ToTable("Reservation_Services", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.Room", b =>
                {
                    b.Property<int>("RoomNumber")
                        .HasColumnType("int")
                        .HasColumnName("Room_Number");

                    b.Property<string>("Availability")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("Hotel_Id");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("Type_Id");

                    b.HasKey("RoomNumber")
                        .HasName("PK__Room__353A906EDA5F5670");

                    b.HasIndex("HotelId");

                    b.HasIndex("TypeId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("HumanResourceProject.Models.RoomType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Type_Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"), 1L, 1);

                    b.Property<string>("BedType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TypeId")
                        .HasName("PK__Room_Typ__FE90DD9EB4C0A9EC");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("Room_Type", (string)null);
                });

            modelBuilder.Entity("Entities.Models.RefreshToken", b =>
                {
                    b.HasOne("HumanResourceProject.Models.Client", "Client")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("HumanResourceProject.Models.Notification", b =>
                {
                    b.HasOne("HumanResourceProject.Models.Client", "ReceiverClient")
                        .WithMany("NotificationReceiverClients")
                        .HasForeignKey("ReceiverClientId")
                        .IsRequired()
                        .HasConstraintName("FK__Notificat__Recei__3A81B327");

                    b.HasOne("HumanResourceProject.Models.Reservation", "Reservation")
                        .WithMany("Notifications")
                        .HasForeignKey("ReservationId")
                        .IsRequired()
                        .HasConstraintName("FK__Notificat__Reser__38996AB5");

                    b.HasOne("HumanResourceProject.Models.Client", "SenderClient")
                        .WithMany("NotificationSenderClients")
                        .HasForeignKey("SenderClientId")
                        .IsRequired()
                        .HasConstraintName("FK__Notificat__Sende__398D8EEE");

                    b.Navigation("ReceiverClient");

                    b.Navigation("Reservation");

                    b.Navigation("SenderClient");
                });

            modelBuilder.Entity("HumanResourceProject.Models.Reservation", b =>
                {
                    b.HasOne("HumanResourceProject.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("FK__Reservati__Clien__2F10007B");

                    b.HasOne("HumanResourceProject.Models.Room", "RoomNumberNavigation")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomNumber")
                        .IsRequired()
                        .HasConstraintName("FK__Reservati__Room___300424B4");

                    b.Navigation("Client");

                    b.Navigation("RoomNumberNavigation");
                });

            modelBuilder.Entity("HumanResourceProject.Models.ReservationService", b =>
                {
                    b.HasOne("HumanResourceProject.Models.Reservation", "Reservation")
                        .WithMany("ReservationServices")
                        .HasForeignKey("ReservationId")
                        .IsRequired()
                        .HasConstraintName("FK__Reservati__Reser__34C8D9D1");

                    b.HasOne("HumanResourceProject.Models.ExtraService", "Services")
                        .WithMany("ReservationServices")
                        .HasForeignKey("ServicesId")
                        .IsRequired()
                        .HasConstraintName("FK__Reservati__Servi__35BCFE0A");

                    b.Navigation("Reservation");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("HumanResourceProject.Models.Room", b =>
                {
                    b.HasOne("HumanResourceProject.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .IsRequired()
                        .HasConstraintName("FK__Room__Hotel_Id__2B3F6F97");

                    b.HasOne("HumanResourceProject.Models.RoomType", "Type")
                        .WithMany("Rooms")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Room__Type_Id__2C3393D0");

                    b.Navigation("Hotel");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("HumanResourceProject.Models.Client", b =>
                {
                    b.Navigation("NotificationReceiverClients");

                    b.Navigation("NotificationSenderClients");

                    b.Navigation("RefreshTokens");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HumanResourceProject.Models.ExtraService", b =>
                {
                    b.Navigation("ReservationServices");
                });

            modelBuilder.Entity("HumanResourceProject.Models.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HumanResourceProject.Models.Reservation", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("ReservationServices");
                });

            modelBuilder.Entity("HumanResourceProject.Models.Room", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HumanResourceProject.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
