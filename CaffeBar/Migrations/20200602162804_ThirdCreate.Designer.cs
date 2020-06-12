﻿// <auto-generated />
using System;
using CaffeBar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaffeBar.Migrations
{
    [DbContext(typeof(CaffeContext))]
    [Migration("20200602162804_ThirdCreate")]
    partial class ThirdCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaffeBar.Data.BillDrink", b =>
                {
                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.HasKey("BillId", "DrinkId");

                    b.HasIndex("DrinkId");

                    b.ToTable("BillDrink");
                });

            modelBuilder.Entity("CaffeBar.Data.CaffeAuth", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Auth");
                });

            modelBuilder.Entity("CaffeBar.Models.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<float>("TotalPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f);

                    b.Property<int>("WaiterId")
                        .HasColumnType("int");

                    b.HasKey("BillId");

                    b.HasIndex("TableId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("CaffeBar.Models.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("TaxRate")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrinkId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("CaffeBar.Models.Guests", b =>
                {
                    b.Property<int>("GuestsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumOfPersons")
                        .HasColumnType("int");

                    b.Property<bool>("Reservation")
                        .HasColumnType("bit");

                    b.Property<string>("ReservationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("GuestsId");

                    b.HasIndex("TableId")
                        .IsUnique();

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("CaffeBar.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Marking")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Taken")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TableId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("CaffeBar.Models.Waiter", b =>
                {
                    b.Property<int>("WaiterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Phone")
                        .HasColumnType("real");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WaiterId");

                    b.ToTable("Waiters");
                });

            modelBuilder.Entity("CaffeBar.Data.BillDrink", b =>
                {
                    b.HasOne("CaffeBar.Models.Bill", "Bill")
                        .WithMany("BillDrinks")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaffeBar.Models.Drink", "Drink")
                        .WithMany("BillDrinks")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaffeBar.Models.Bill", b =>
                {
                    b.HasOne("CaffeBar.Models.Table", "Table")
                        .WithMany("Bills")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaffeBar.Models.Waiter", "Waiter")
                        .WithMany("Bills")
                        .HasForeignKey("WaiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaffeBar.Models.Guests", b =>
                {
                    b.HasOne("CaffeBar.Models.Table", "Table")
                        .WithOne("Guests")
                        .HasForeignKey("CaffeBar.Models.Guests", "TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}