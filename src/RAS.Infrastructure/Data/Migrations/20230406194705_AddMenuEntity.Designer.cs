﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RAS.Infrastructure.Data;

#nullable disable

namespace RAS.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230406194705_AddMenuEntity")]
    partial class AddMenuEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RAS.Core.Aggregates.Menu.Entities.MenuEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("RAS.Core.Aggregates.Menu.Entities.MenuItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MenuItems", (string)null);
                });

            modelBuilder.Entity("RAS.Core.Aggregates.Menu.Entities.MenuMenuItemEntity", b =>
                {
                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MenuId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("MenuMenuItems", (string)null);
                });

            modelBuilder.Entity("RAS.Core.Aggregates.User.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTimeOffset?>("ModifiedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<DateTimeOffset>("PasswordChangedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(20)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(32)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("RAS.Core.Aggregates.Menu.Entities.MenuMenuItemEntity", b =>
                {
                    b.HasOne("RAS.Core.Aggregates.Menu.Entities.MenuEntity", "Menu")
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RAS.Core.Aggregates.Menu.Entities.MenuItemEntity", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("RAS.Core.Aggregates.Menu.Entities.MenuEntity", b =>
                {
                    b.Navigation("MenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}