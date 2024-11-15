﻿// <auto-generated />
using System;
using BookingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookingService.Infrastructure.Migrations
{
    [DbContext(typeof(BookingServiceDbContext))]
    partial class BookingServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookingService.Core.Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("BookingService.Core.Entities.Reservation.ReservationDetail", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReservationId"));

                    b.Property<DateOnly>("ArrivalDate")
                        .HasColumnType("date");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("DepartureDate")
                        .HasColumnType("date");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("integer");

                    b.Property<string>("ReservationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<double>("TotalCost")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalCostDue")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalCostPaid")
                        .HasColumnType("double precision");

                    b.HasKey("ReservationId");

                    b.HasIndex("RoomId");

                    b.ToTable("ReservationDetails");
                });

            modelBuilder.Entity("BookingService.Core.Entities.Room.RoomDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("BasePrice")
                        .HasColumnType("double precision");

                    b.Property<int>("Beds")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<int>("MaxAdults")
                        .HasColumnType("integer");

                    b.Property<int?>("MaxChildren")
                        .HasColumnType("integer");

                    b.Property<int?>("MaxInfants")
                        .HasColumnType("integer");

                    b.Property<int>("MaxTotalOccupants")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("RoomDetails");
                });

            modelBuilder.Entity("BookingService.Core.Entities.Room.RoomFacility", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RoomDetailId")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("RoomDetailId");

                    b.ToTable("RoomFacility");
                });

            modelBuilder.Entity("BookingService.Core.Entities.Room.RoomFeature", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RoomDetailId")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("RoomDetailId");

                    b.ToTable("RoomFeature");
                });

            modelBuilder.Entity("BookingService.Core.Entities.Translation.Translation", b =>
                {
                    b.Property<string>("ResourceKey")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Culture")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("TranslatedValue")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("ResourceKey", "Culture");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("PictureRoomDetail", b =>
                {
                    b.Property<int>("PicturesId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomDetailsId")
                        .HasColumnType("integer");

                    b.HasKey("PicturesId", "RoomDetailsId");

                    b.HasIndex("RoomDetailsId");

                    b.ToTable("PictureRoomDetail");
                });

            modelBuilder.Entity("BookingService.Core.Entities.Reservation.ReservationDetail", b =>
                {
                    b.HasOne("BookingService.Core.Entities.Room.RoomDetail", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BookingService.Core.Entities.Room.RoomFacility", b =>
                {
                    b.HasOne("BookingService.Core.Entities.Room.RoomDetail", null)
                        .WithMany("Facilities")
                        .HasForeignKey("RoomDetailId");
                });

            modelBuilder.Entity("BookingService.Core.Entities.Room.RoomFeature", b =>
                {
                    b.HasOne("BookingService.Core.Entities.Room.RoomDetail", null)
                        .WithMany("Features")
                        .HasForeignKey("RoomDetailId");
                });

            modelBuilder.Entity("PictureRoomDetail", b =>
                {
                    b.HasOne("BookingService.Core.Entities.Picture", null)
                        .WithMany()
                        .HasForeignKey("PicturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingService.Core.Entities.Room.RoomDetail", null)
                        .WithMany()
                        .HasForeignKey("RoomDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingService.Core.Entities.Room.RoomDetail", b =>
                {
                    b.Navigation("Facilities");

                    b.Navigation("Features");
                });
#pragma warning restore 612, 618
        }
    }
}
