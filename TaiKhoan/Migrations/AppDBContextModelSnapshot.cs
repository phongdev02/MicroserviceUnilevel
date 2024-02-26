﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaiKhoan.Context;

#nullable disable

namespace TaiKhoan.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaiKhoan.Models.Nhanvien", b =>
                {
                    b.Property<int>("NvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NvId"));

                    b.Property<int?>("ChucvuId")
                        .HasColumnType("int");

                    b.Property<string>("GmailNv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhanhNv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatkhauNv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayLam")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TkId")
                        .HasColumnType("int");

                    b.Property<bool?>("TrangthaiNv")
                        .HasColumnType("bit");

                    b.HasKey("NvId");

                    b.ToTable("Nhanviens");

                    b.HasData(
                        new
                        {
                            NvId = 1,
                            ChucvuId = 1,
                            GmailNv = "gmail@gmail.com",
                            HinhanhNv = "avatar.jpg",
                            HoTen = "John Doe",
                            MatkhauNv = "password123",
                            NgayLam = new DateTime(2024, 1, 27, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6115),
                            NgayTao = new DateTime(2024, 2, 26, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6103),
                            Sdt = "123456789",
                            TkId = 1,
                            TrangthaiNv = true
                        },
                        new
                        {
                            NvId = 2,
                            ChucvuId = 1,
                            GmailNv = "gmail@gmail.com",
                            HinhanhNv = "avatar.jpg",
                            HoTen = "John Doe",
                            MatkhauNv = "password123",
                            NgayLam = new DateTime(2024, 1, 27, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6142),
                            NgayTao = new DateTime(2024, 2, 26, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6142),
                            Sdt = "123456789",
                            TkId = 1,
                            TrangthaiNv = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
