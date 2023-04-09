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
    [Migration("20230331222442_RoleNavProp")]
    partial class RoleNavProp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                            RoleId = new Guid("659195a5-3667-4350-b4c4-550fa8f1908e")
                        },
                        new
                        {
                            UserId = new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                            RoleId = new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e")
                        },
                        new
                        {
                            UserId = new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                            RoleId = new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e")
                        },
                        new
                        {
                            UserId = new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                            RoleId = new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e")
                        },
                        new
                        {
                            UserId = new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                            RoleId = new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e")
                        },
                        new
                        {
                            UserId = new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                            RoleId = new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e")
                        },
                        new
                        {
                            UserId = new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                            RoleId = new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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
                            Id = new Guid("f094d8a1-3552-43df-a27b-7448f72c467f"),
                            NameAndSurname = "Tom Hanks"
                        },
                        new
                        {
                            Id = new Guid("ffcf9bde-784e-4b60-a295-444fcf32f9f2"),
                            NameAndSurname = "Tom Cruise"
                        },
                        new
                        {
                            Id = new Guid("5c4433b8-1480-4596-b10b-856fff5482ff"),
                            NameAndSurname = "Ivan"
                        },
                        new
                        {
                            Id = new Guid("a4ec67de-4607-4775-9e83-3ad59426c993"),
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

            modelBuilder.Entity("video_pujcovna_back.Models.ReservationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasIndex("UserId");

                    b.HasIndex("VideotapeId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.RoleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<Guid?>("UserModelId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.HasIndex("UserModelId");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("659195a5-3667-4350-b4c4-550fa8f1908e"),
                            Description = "System administrator",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("5fc03444-56b7-4ca7-a7de-dd4bec93e44e"),
                            Description = "Branch lead",
                            Name = "lead",
                            NormalizedName = "LEAD"
                        },
                        new
                        {
                            Id = new Guid("c8ef7cfe-631d-4fdf-8705-9514a78d7f4e"),
                            Description = "Regular employee",
                            Name = "employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = new Guid("da055781-5fd2-47d7-86a1-84b2c5ddba08"),
                            Description = "Regular customer",
                            Name = "customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("video_pujcovna_back.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("69c5507d-401b-4998-ab4f-d035d5b2903c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5b2aa2b4-a1e2-4979-9837-15baeadd0651",
                            Email = "honza@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Honza"
                        },
                        new
                        {
                            Id = new Guid("294c5b1d-7d26-4a6f-a8a5-6f02446f4550"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9adeae96-bf4c-4245-9a46-3c61bc660a83",
                            Email = "jan@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Jan"
                        },
                        new
                        {
                            Id = new Guid("63df0b47-06bb-45a4-8826-790231938dde"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "37b2fcb4-777c-441e-b8f9-025d8c749891",
                            Email = "pavel@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Pavel"
                        },
                        new
                        {
                            Id = new Guid("b8db233c-63c3-4148-bc10-78a48ce0b2bc"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "440bb0c7-5fec-4b4c-b65b-ee4120e4a29a",
                            Email = "petr@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "Petr"
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.RoleModel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.RoleModel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("video_pujcovna_back.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("video_pujcovna_back.Models.RoleModel", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.UserModel", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.UserModel", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
