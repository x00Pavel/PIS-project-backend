﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using video_pujcovna_back.Models;

#nullable disable

namespace video_pujcovna_back.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230401104425_Payment")]
    partial class Payment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ActorModelVideotapeModel", b =>
                {
                    b.Property<Guid>("ActorsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VideotapesId")
                        .HasColumnType("char(36)");

                    b.HasKey("ActorsId", "VideotapesId");

                    b.HasIndex("VideotapesId");

                    b.ToTable("ActorModelVideotapeModel");
                });

            modelBuilder.Entity("GenreModelVideotapeModel", b =>
                {
                    b.Property<string>("GenreName")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("VideotapesId")
                        .HasColumnType("char(36)");

                    b.HasKey("GenreName", "VideotapesId");

                    b.HasIndex("VideotapesId");

                    b.ToTable("GenreModelVideotapeModel");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.ActorModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("NameAndSurname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Actor");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5a93a7f5-8977-41a2-a58d-dae3db86fb4a"),
                            NameAndSurname = "Tom Hanks"
                        },
                        new
                        {
                            Id = new Guid("b484f1c3-9d2d-4fb6-9aeb-f8bc2bf710a3"),
                            NameAndSurname = "Tom Cruise"
                        },
                        new
                        {
                            Id = new Guid("9c3e266a-008b-405c-b966-ff373b16a86e"),
                            NameAndSurname = "Ivan"
                        },
                        new
                        {
                            Id = new Guid("278dbfd6-d98a-494d-8a74-e1c77cf222a8"),
                            NameAndSurname = "Honza"
                        });
                });

            modelBuilder.Entity("video_pujcovna_back.Models.GenreModel", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Name");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Name = "action"
                        },
                        new
                        {
                            Name = "adventure"
                        },
                        new
                        {
                            Name = "comedy"
                        });
                });

            modelBuilder.Entity("video_pujcovna_back.Models.PaymentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("char(36)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.ReservationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VideotapeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.HasIndex("VideotapeId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.RoleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"),
                            Description = "System administrator",
                            Name = "admin",
                            Priority = 0
                        },
                        new
                        {
                            Id = new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"),
                            Description = "Branch lead",
                            Name = "lead",
                            Priority = 20
                        },
                        new
                        {
                            Id = new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"),
                            Description = "Regular employee",
                            Name = "employee",
                            Priority = 40
                        },
                        new
                        {
                            Id = new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"),
                            Description = "Regular customer",
                            Name = "customer",
                            Priority = 60
                        });
                });

            modelBuilder.Entity("video_pujcovna_back.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9fc08dc4-e291-4f84-89b2-8f9fce31d6a7"),
                            Password = "1234",
                            RoleId = new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"),
                            Username = "honza@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("0244de64-baa0-457d-add5-27eb4e7b5779"),
                            Password = "1234",
                            RoleId = new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"),
                            Username = "jan@gmail.com"
                        });
                });

            modelBuilder.Entity("video_pujcovna_back.Models.VideotapeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("VideTape");
                });

            modelBuilder.Entity("ActorModelVideotapeModel", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.ActorModel", null)
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("video_pujcovna_back.Models.VideotapeModel", null)
                        .WithMany()
                        .HasForeignKey("VideotapesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreModelVideotapeModel", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.GenreModel", null)
                        .WithMany()
                        .HasForeignKey("GenreName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("video_pujcovna_back.Models.VideotapeModel", null)
                        .WithMany()
                        .HasForeignKey("VideotapesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("video_pujcovna_back.Models.PaymentModel", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.PaymentModel", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.ReservationModel", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.PaymentModel", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("video_pujcovna_back.Models.UserModel", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("video_pujcovna_back.Models.VideotapeModel", "Videotape")
                        .WithMany()
                        .HasForeignKey("VideotapeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");

                    b.Navigation("User");

                    b.Navigation("Videotape");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.UserModel", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.RoleModel", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.UserModel", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
