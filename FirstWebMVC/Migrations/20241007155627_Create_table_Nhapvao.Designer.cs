﻿// <auto-generated />
using FirstWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstWebMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241007155627_Create_table_Nhapvao")]
    partial class Create_table_Nhapvao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("FirstWebMVC.Models.Customer", b =>
                {
                    b.Property<string>("Hoten")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("diachi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Hoten");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FirstWebMVC.Models.Dangnhap", b =>
                {
                    b.Property<string>("CCCD")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Hoten")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Quequan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CCCD");

                    b.ToTable("Dangnhap");

                    b.HasDiscriminator().HasValue("Dangnhap");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FirstWebMVC.Models.Lop", b =>
                {
                    b.Property<string>("Person")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.HasKey("Person");

                    b.ToTable("Lops");
                });

            modelBuilder.Entity("FirstWebMVC.Models.Person", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("FirstWebMVC.Models.Sinhvien", b =>
                {
                    b.Property<string>("nguoi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hoten")
                        .HasColumnType("TEXT");

                    b.Property<string>("diachi")
                        .HasColumnType("TEXT");

                    b.HasKey("nguoi");

                    b.ToTable("Sinhvien");
                });

            modelBuilder.Entity("firstWebMVC.model.Nhapvao", b =>
                {
                    b.HasBaseType("FirstWebMVC.Models.Dangnhap");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Masinhvien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Nhapvao");
                });
#pragma warning restore 612, 618
        }
    }
}
