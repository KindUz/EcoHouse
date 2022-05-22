﻿// <auto-generated />
using System;
using EcoHouse.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoHouse.Storage.Migrations
{
    [DbContext(typeof(UniversityContext))]
    partial class UniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EcoHouse.Storage.Entities.Another_Adresses", b =>
                {
                    b.Property<int>("Address_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Address_ID"), 1L, 1);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_Of_Apartment")
                        .HasColumnType("int");

                    b.Property<int>("Number_Of_House")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Address_ID");

                    b.ToTable("Another_Adresses");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name_Of_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryId"), 1L, 1);

                    b.Property<int>("AddressID")
                        .HasColumnType("int");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("DeliveryId");

                    b.HasIndex("AddressID");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Dish", b =>
                {
                    b.Property<int>("Dish_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dish_ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mass")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Recipe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Structure_")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Dish_ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("Structure_");

                    b.ToTable("dishes");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Food_Features", b =>
                {
                    b.Property<int>("Food_FeaturesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Food_FeaturesId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Food_FeaturesId");

                    b.ToTable("Food_Features");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Main_Address", b =>
                {
                    b.Property<int>("Address_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Address_ID"), 1L, 1);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_Of_Apartment")
                        .HasColumnType("int");

                    b.Property<int>("Number_Of_House")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Address_ID");

                    b.ToTable("main_Addresses");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Order", b =>
                {
                    b.Property<int>("OrdersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdersID"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Delivery_ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DishID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("OrdersID");

                    b.HasIndex("Delivery_ID");

                    b.HasIndex("DishID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Structure", b =>
                {
                    b.Property<int>("Structure_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Structure_ID"), 1L, 1);

                    b.Property<float>("Calorific")
                        .HasColumnType("real");

                    b.Property<float>("Carbohydrates")
                        .HasColumnType("real");

                    b.Property<float>("Fats")
                        .HasColumnType("real");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Proteins")
                        .HasColumnType("real");

                    b.HasKey("Structure_ID");

                    b.ToTable("structures");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Food_Features_ID")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrdersID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.HasIndex("Food_Features_ID");

                    b.HasIndex("OrdersID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Delivery", b =>
                {
                    b.HasOne("EcoHouse.Storage.Entities.Another_Adresses", "Another_Adresses")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Another_Adresses");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Dish", b =>
                {
                    b.HasOne("EcoHouse.Storage.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcoHouse.Storage.Entities.Structure", "Structure")
                        .WithMany()
                        .HasForeignKey("Structure_")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.Order", b =>
                {
                    b.HasOne("EcoHouse.Storage.Entities.Delivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("Delivery_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcoHouse.Storage.Entities.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("EcoHouse.Storage.Entities.User", b =>
                {
                    b.HasOne("EcoHouse.Storage.Entities.Main_Address", "Main_Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("EcoHouse.Storage.Entities.Food_Features", "Food_Features")
                        .WithMany()
                        .HasForeignKey("Food_Features_ID");

                    b.HasOne("EcoHouse.Storage.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrdersID");

                    b.Navigation("Food_Features");

                    b.Navigation("Main_Address");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
