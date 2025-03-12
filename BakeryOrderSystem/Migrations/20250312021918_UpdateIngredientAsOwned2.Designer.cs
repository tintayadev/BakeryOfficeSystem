﻿// <auto-generated />
using System;
using BakeryProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BakeryOrderSystem.Migrations
{
    [DbContext(typeof(BakeryDbContext))]
    [Migration("20250312021918_UpdateIngredientAsOwned2")]
    partial class UpdateIngredientAsOwned2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("BakeryProject.Domain.Entities.BakeryOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChefId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceSchedule")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChefId");

                    b.ToTable("BakeryOffices");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.Bread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BreadType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<int>("CookingTemperature")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CookingTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FermentTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("RestingTime")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Breads");

                    b.HasDiscriminator<string>("BreadType").HasValue("Bread");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BakeryOfficeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPrepared")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BakeryOfficeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BreadId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BreadId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.PastryChef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Specialties")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PastryChefs");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.Baguette", b =>
                {
                    b.HasBaseType("BakeryProject.Domain.Entities.Bread");

                    b.HasDiscriminator().HasValue("Baguette");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.HamburgerBun", b =>
                {
                    b.HasBaseType("BakeryProject.Domain.Entities.Bread");

                    b.HasDiscriminator().HasValue("HamburgerBun");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.MilkBread", b =>
                {
                    b.HasBaseType("BakeryProject.Domain.Entities.Bread");

                    b.HasDiscriminator().HasValue("MilkBread");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.WhiteBread", b =>
                {
                    b.HasBaseType("BakeryProject.Domain.Entities.Bread");

                    b.HasDiscriminator().HasValue("WhiteBread");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.BakeryOffice", b =>
                {
                    b.HasOne("BakeryProject.Domain.Entities.PastryChef", "Chef")
                        .WithMany()
                        .HasForeignKey("ChefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chef");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.Bread", b =>
                {
                    b.OwnsMany("BakeryProject.Domain.Entities.Ingredient", "BaseIngredients", b1 =>
                        {
                            b1.Property<int>("BreadId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Quantity")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("BreadId", "Id");

                            b1.ToTable("Ingredient");

                            b1.WithOwner()
                                .HasForeignKey("BreadId");
                        });

                    b.Navigation("BaseIngredients");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.Order", b =>
                {
                    b.HasOne("BakeryProject.Domain.Entities.BakeryOffice", null)
                        .WithMany("Orders")
                        .HasForeignKey("BakeryOfficeId");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("BakeryProject.Domain.Entities.Bread", "Bread")
                        .WithMany()
                        .HasForeignKey("BreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BakeryProject.Domain.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.Navigation("Bread");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.BakeryOffice", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BakeryProject.Domain.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
