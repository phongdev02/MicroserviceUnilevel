﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaiKhoan.Context;

#nullable disable

namespace TaiKhoan.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240301024843_addCVAndRole")]
    partial class addCVAndRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaiKhoan.Models.CapQuyen", b =>
                {
                    b.Property<int>("QuyenTruycapId")
                        .HasColumnType("int");

                    b.Property<int>("ChucvuId")
                        .HasColumnType("int");

                    b.HasKey("QuyenTruycapId", "ChucvuId");

                    b.HasIndex("ChucvuId");

                    b.ToTable("CapQuyen");
                });

            modelBuilder.Entity("TaiKhoan.Models.ChucVu", b =>
                {
                    b.Property<int>("ChucvuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChucvuId"));

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhomcvId")
                        .HasColumnType("int");

                    b.Property<string>("TenCv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChucvuId");

                    b.HasIndex("NhomcvId");

                    b.ToTable("chucVus");
                });

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
                });

            modelBuilder.Entity("TaiKhoan.Models.NhomChucVu", b =>
                {
                    b.Property<int>("NhomcvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhomcvId"));

                    b.Property<int?>("Quyen")
                        .HasColumnType("int");

                    b.Property<string>("TenNcv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NhomcvId");

                    b.ToTable("nhomChucVus");
                });

            modelBuilder.Entity("TaiKhoan.Models.NhomQuyenTruyCap", b =>
                {
                    b.Property<int>("NhomQuyenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhomQuyenId"));

                    b.Property<string>("TenNq")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NhomQuyenId");

                    b.ToTable("nhomQuyenTruyCaps");
                });

            modelBuilder.Entity("TaiKhoan.Models.PhanCapNV", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("NvID")
                        .HasColumnType("int");

                    b.Property<int>("NvqlID")
                        .HasColumnType("int");

                    b.Property<bool>("Trangthai")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("PhanCapNVs");
                });

            modelBuilder.Entity("TaiKhoan.Models.Quyen", b =>
                {
                    b.Property<int>("QuyenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenId"));

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuyenId");

                    b.ToTable("quyens");
                });

            modelBuilder.Entity("TaiKhoan.Models.QuyenTruyCap", b =>
                {
                    b.Property<int>("QuyenTruycapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenTruycapId"));

                    b.Property<int?>("NhomQuyenId")
                        .HasColumnType("int");

                    b.Property<int?>("QuyenId")
                        .HasColumnType("int");

                    b.Property<string>("TenQuyenTc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuyenTruycapId");

                    b.HasIndex("NhomQuyenId");

                    b.HasIndex("QuyenId");

                    b.ToTable("quyenTruyCaps");
                });

            modelBuilder.Entity("TaiKhoan.Models.CapQuyen", b =>
                {
                    b.HasOne("TaiKhoan.Models.ChucVu", "ChucVu")
                        .WithMany("CapQuyens")
                        .HasForeignKey("ChucvuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaiKhoan.Models.QuyenTruyCap", "QuyenTruyCap")
                        .WithMany("CapQuyens")
                        .HasForeignKey("QuyenTruycapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");

                    b.Navigation("QuyenTruyCap");
                });

            modelBuilder.Entity("TaiKhoan.Models.ChucVu", b =>
                {
                    b.HasOne("TaiKhoan.Models.NhomChucVu", "Nhomcv")
                        .WithMany("ChucVus")
                        .HasForeignKey("NhomcvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nhomcv");
                });

            modelBuilder.Entity("TaiKhoan.Models.QuyenTruyCap", b =>
                {
                    b.HasOne("TaiKhoan.Models.NhomQuyenTruyCap", "NhomQuyen")
                        .WithMany("QuyenTruyCaps")
                        .HasForeignKey("NhomQuyenId");

                    b.HasOne("TaiKhoan.Models.Quyen", "Quyen")
                        .WithMany("QuyenTruyCaps")
                        .HasForeignKey("QuyenId");

                    b.Navigation("NhomQuyen");

                    b.Navigation("Quyen");
                });

            modelBuilder.Entity("TaiKhoan.Models.ChucVu", b =>
                {
                    b.Navigation("CapQuyens");
                });

            modelBuilder.Entity("TaiKhoan.Models.NhomChucVu", b =>
                {
                    b.Navigation("ChucVus");
                });

            modelBuilder.Entity("TaiKhoan.Models.NhomQuyenTruyCap", b =>
                {
                    b.Navigation("QuyenTruyCaps");
                });

            modelBuilder.Entity("TaiKhoan.Models.Quyen", b =>
                {
                    b.Navigation("QuyenTruyCaps");
                });

            modelBuilder.Entity("TaiKhoan.Models.QuyenTruyCap", b =>
                {
                    b.Navigation("CapQuyens");
                });
#pragma warning restore 612, 618
        }
    }
}