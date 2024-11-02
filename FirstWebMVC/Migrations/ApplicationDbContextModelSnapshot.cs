﻿// <auto-generated />
using FirstWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstWebMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("FirstWebMVC.Models.Person", b =>
                {
                    b.Property<string>("PersonID")
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

                    b.HasKey("PersonID");

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Person");

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("FirstWebMVC.Models.Employee", b =>
                {
                    b.HasBaseType("FirstWebMVC.Models.Person");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
