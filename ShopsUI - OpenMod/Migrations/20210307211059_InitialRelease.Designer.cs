﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopsUI.Database;

namespace ShopsUI.Migrations
{
    [DbContext(typeof(ShopsDbContext))]
    [Migration("20210307211059_InitialRelease")]
    partial class InitialRelease
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShopsUI.Database.Models.ItemGroupModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsWhitelist")
                        .HasColumnType("tinyint(1)");

                    b.Property<ushort>("ItemShopItemId")
                        .HasColumnType("smallint unsigned");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ItemShopItemId");

                    b.ToTable("ShopsUI_ItemGroups");
                });

            modelBuilder.Entity("ShopsUI.Database.Models.ItemShopModel", b =>
                {
                    b.Property<ushort>("ItemId")
                        .HasColumnType("smallint unsigned");

                    b.Property<decimal?>("BuyPrice")
                        .HasColumnType("decimal(24,2)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<decimal?>("SellPrice")
                        .HasColumnType("decimal(24,2)");

                    b.HasKey("ItemId");

                    b.ToTable("ShopsUI_ItemShops");
                });

            modelBuilder.Entity("ShopsUI.Database.Models.VehicleGroupModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsWhitelist")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ushort>("VehicleShopVehicleId")
                        .HasColumnType("smallint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("VehicleShopVehicleId");

                    b.ToTable("ShopsUI_VehicleGroups");
                });

            modelBuilder.Entity("ShopsUI.Database.Models.VehicleShopModel", b =>
                {
                    b.Property<ushort>("VehicleId")
                        .HasColumnType("smallint unsigned");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(24,2)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.ToTable("ShopsUI_VehicleShops");
                });

            modelBuilder.Entity("ShopsUI.Database.Models.ItemGroupModel", b =>
                {
                    b.HasOne("ShopsUI.Database.Models.ItemShopModel", "ItemShop")
                        .WithMany("AuthGroups")
                        .HasForeignKey("ItemShopItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopsUI.Database.Models.VehicleGroupModel", b =>
                {
                    b.HasOne("ShopsUI.Database.Models.VehicleShopModel", "VehicleShop")
                        .WithMany("AuthGroups")
                        .HasForeignKey("VehicleShopVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
