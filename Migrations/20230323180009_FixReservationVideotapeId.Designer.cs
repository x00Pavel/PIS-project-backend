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
    [Migration("20230323180009_FixReservationVideotapeId")]
    partial class FixReservationVideotapeId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("video_pujcovna_back.Models.ReservationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VideotapeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

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
                });

            modelBuilder.Entity("video_pujcovna_back.Models.VideotapeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("VideTape");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.ReservationModel", b =>
                {
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