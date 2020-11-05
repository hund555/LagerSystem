﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(LagerContext))]
    partial class LagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Discription = "Cat6 netkabel 3 meter langt",
                            ItemName = "Cat6 3m"
                        },
                        new
                        {
                            ItemId = 2,
                            Discription = "Cat6 netkabel 4 meter langt",
                            ItemName = "Cat6 4m"
                        },
                        new
                        {
                            ItemId = 3,
                            Discription = "Cat6 netkabel 6 meter langt",
                            ItemName = "Cat6 6m"
                        },
                        new
                        {
                            ItemId = 4,
                            Discription = "HP bærbar i5-4210M, 16GB ram",
                            ItemName = "HP bærbar"
                        },
                        new
                        {
                            ItemId = 5,
                            Discription = "HDMI kabel 1 meter langt",
                            ItemName = "HDMI 1m"
                        },
                        new
                        {
                            ItemId = 6,
                            Discription = "HDMI kabel 3 meter langt",
                            ItemName = "HDMI 3m"
                        },
                        new
                        {
                            ItemId = 7,
                            Discription = "Logitech mus",
                            ItemName = "Logitech mus"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Allan"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Item", b =>
                {
                    b.HasOne("DataLayer.Entities.User", "User")
                        .WithMany("Items")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
