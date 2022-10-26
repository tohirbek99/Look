﻿// <auto-generated />
using System;
using Look.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Look.Migrations
{
    [DbContext(typeof(DBConnection))]
    partial class DBConnectionModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Look.Models.Costomer", b =>
                {
                    b.Property<int>("CostomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CostomerId"), 1L, 1);

                    b.Property<string>("CostemerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNamber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CostomerId");

                    b.HasIndex("OrderId");

                    b.ToTable("Costomers");
                });

            modelBuilder.Entity("Look.Models.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrinkId"), 1L, 1);

                    b.Property<string>("DrinkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmploeeId")
                        .HasColumnType("int");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Volume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrinkId");

                    b.HasIndex("EmploeeId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("Look.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNamber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("OrderId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Look.Models.FastFood", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"), 1L, 1);

                    b.Property<int>("EmploeeId")
                        .HasColumnType("int");

                    b.Property<string>("FoodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodId");

                    b.HasIndex("EmploeeId");

                    b.ToTable("FastFoods");
                });

            modelBuilder.Entity("Look.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("Count")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Look.Models.Costomer", b =>
                {
                    b.HasOne("Look.Models.Order", "Orders")
                        .WithMany("Costomers")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Look.Models.Drink", b =>
                {
                    b.HasOne("Look.Models.Employee", "Employees")
                        .WithMany("Drinks")
                        .HasForeignKey("EmploeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Look.Models.Employee", b =>
                {
                    b.HasOne("Look.Models.Order", "Orders")
                        .WithMany("Employees")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Look.Models.FastFood", b =>
                {
                    b.HasOne("Look.Models.Employee", "Employees")
                        .WithMany("FastFoods")
                        .HasForeignKey("EmploeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Look.Models.Employee", b =>
                {
                    b.Navigation("Drinks");

                    b.Navigation("FastFoods");
                });

            modelBuilder.Entity("Look.Models.Order", b =>
                {
                    b.Navigation("Costomers");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
