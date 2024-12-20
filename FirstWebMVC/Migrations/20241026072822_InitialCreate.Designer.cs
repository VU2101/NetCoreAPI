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
    [Migration("20241026072822_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

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
#pragma warning restore 612, 618
        }
    }
}
