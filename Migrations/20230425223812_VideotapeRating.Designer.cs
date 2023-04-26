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
    [Migration("20230425223812_VideotapeRating")]
    partial class VideotapeRating
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
                            Id = new Guid("30b4eff8-93e7-44aa-8eb6-f4ad3e7a414b"),
                            NameAndSurname = "Tom Hanks"
                        },
                        new
                        {
                            Id = new Guid("a6307255-4b26-4759-b2c5-b2c467a7e8e4"),
                            NameAndSurname = "Tom Cruise"
                        },
                        new
                        {
                            Id = new Guid("d12c9848-5bb3-41e0-a84c-96a966750129"),
                            NameAndSurname = "Ivan"
                        },
                        new
                        {
                            Id = new Guid("e94669cc-2089-494b-a260-615ab41685e0"),
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

                    b.Property<bool>("Paid")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.ReservationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

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

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

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

            modelBuilder.Entity("video_pujcovna_back.Models.StockModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stock");

                    b.HasData(
                        new
                        {
                            Id = new Guid("30b4eff8-93e7-44aa-8eb6-f4ad3e7a414a"),
                            Description = "Main stock description",
                            Name = "Main stock"
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

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
                            ConcurrencyStamp = "211a6d99-e5d6-4732-8a9c-aed3b8e1caba",
                            Deleted = false,
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
                            ConcurrencyStamp = "f9c59c1f-a03b-4fb2-92d9-8c22e97e18df",
                            Deleted = false,
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
                            ConcurrencyStamp = "a8c618a2-eb6a-42cc-83b0-e2ba4e8dd734",
                            Deleted = false,
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
                            ConcurrencyStamp = "fb2160e0-752a-4360-9e61-30d02d63875e",
                            Deleted = false,
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

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("longtext");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PricePerDay")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("StockId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

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

            modelBuilder.Entity("video_pujcovna_back.Models.VideotapeModel", b =>
                {
                    b.HasOne("video_pujcovna_back.Models.StockModel", "Stock")
                        .WithMany("Videotapes")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.StockModel", b =>
                {
                    b.Navigation("Videotapes");
                });

            modelBuilder.Entity("video_pujcovna_back.Models.UserModel", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
