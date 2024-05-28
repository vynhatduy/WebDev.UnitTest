﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microservices.UserServices.Models;

#nullable disable

namespace Microservices.UserServices.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240518192907_Update_Table_UserRoles")]
    partial class Update_Table_UserRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserServices.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Manager"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("UserServices.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "Da Lat",
                            Name = "Admin",
                            PasswordHash = "417jXAymYami5K2I9KfWZ8VIRwDGLL6uHY1O4k9oDgo=",
                            PasswordSalt = "cPHcz1XNjeym6ge5ayqYHg==",
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            Address = "Da Lat",
                            Name = "Manager",
                            PasswordHash = "MmT0YLSPRI0rWOKytioJRI+gHYDAfIXy02eX/cmLr1Y=",
                            PasswordSalt = "UZe4ZBHvOlFXigygPAbW0A==",
                            Username = "manager"
                        },
                        new
                        {
                            UserId = 3,
                            Address = "Da Lat",
                            Name = "User",
                            PasswordHash = "OIQNbRMlWLhX12Q5n7lIIpUxIa5iNePc5y97VnFThC4=",
                            PasswordSalt = "R50aG5p577nwfhTdcwaoxg==",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("UserServices.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserRoleId = 1,
                            RoleId = 1,
                            Username = "Admin"
                        },
                        new
                        {
                            UserRoleId = 2,
                            RoleId = 2,
                            Username = "Manager"
                        },
                        new
                        {
                            UserRoleId = 3,
                            RoleId = 3,
                            Username = "User"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
