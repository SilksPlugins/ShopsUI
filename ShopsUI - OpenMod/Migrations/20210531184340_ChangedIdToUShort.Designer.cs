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
    [Migration("20210531184340_ChangedIdToUShort")]
    partial class ChangedIdToUShort
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShopsUI.Database.Models.ItemShopModel", b =>
                {
                    b.Property<ushort>("ItemShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint unsigned");

                    b.Property<decimal?>("BuyPrice")
                        .HasColumnType("decimal(24,2)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<decimal?>("SellPrice")
                        .HasColumnType("decimal(24,2)");

                    b.HasKey("ItemShopId");

                    b.ToTable("ShopsUI_ItemShops");
                });

            modelBuilder.Entity("ShopsUI.Database.Models.VehicleShopModel", b =>
                {
                    b.Property<ushort>("VehicleShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint unsigned");

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("decimal(24,2)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("VehicleShopId");

                    b.ToTable("ShopsUI_VehicleShops");
                });
#pragma warning restore 612, 618
        }
    }
}
