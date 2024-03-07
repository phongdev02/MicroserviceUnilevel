﻿// <auto-generated />
using System;
using ChucvuPhanquyen.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChucvuPhanquyen.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240301040931_AdddataoRole")]
    partial class AdddataoRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChucvuPhanquyen.Models.CapQuyen", b =>
                {
                    b.Property<int>("QuyenTruycapId")
                        .HasColumnType("int");

                    b.Property<int>("ChucvuId")
                        .HasColumnType("int");

                    b.HasKey("QuyenTruycapId", "ChucvuId");

                    b.HasIndex("ChucvuId");

                    b.ToTable("CapQuyen");
                });

            modelBuilder.Entity("ChucvuPhanquyen.Models.ChucVu", b =>
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

            modelBuilder.Entity("ChucvuPhanquyen.Models.NhomChucVu", b =>
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

            modelBuilder.Entity("ChucvuPhanquyen.Models.NhomQuyenTruyCap", b =>
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

            modelBuilder.Entity("ChucvuPhanquyen.Models.Quyen", b =>
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

            modelBuilder.Entity("ChucvuPhanquyen.Models.QuyenTruyCap", b =>
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

            modelBuilder.Entity("ChucvuPhanquyen.Models.CapQuyen", b =>
                {
                    b.HasOne("ChucvuPhanquyen.Models.ChucVu", "ChucVu")
                        .WithMany("CapQuyens")
                        .HasForeignKey("ChucvuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChucvuPhanquyen.Models.QuyenTruyCap", "QuyenTruyCap")
                        .WithMany("CapQuyens")
                        .HasForeignKey("QuyenTruycapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");

                    b.Navigation("QuyenTruyCap");
                });

            modelBuilder.Entity("ChucvuPhanquyen.Models.ChucVu", b =>
                {
                    b.HasOne("ChucvuPhanquyen.Models.NhomChucVu", "Nhomcv")
                        .WithMany("ChucVus")
                        .HasForeignKey("NhomcvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nhomcv");
                });

            modelBuilder.Entity("ChucvuPhanquyen.Models.QuyenTruyCap", b =>
                {
                    b.HasOne("ChucvuPhanquyen.Models.NhomQuyenTruyCap", "NhomQuyen")
                        .WithMany("QuyenTruyCaps")
                        .HasForeignKey("NhomQuyenId");

                    b.HasOne("ChucvuPhanquyen.Models.Quyen", "Quyen")
                        .WithMany("QuyenTruyCaps")
                        .HasForeignKey("QuyenId");

                    b.Navigation("NhomQuyen");

                    b.Navigation("Quyen");
                });

            modelBuilder.Entity("ChucvuPhanquyen.Models.ChucVu", b =>
                {
                    b.Navigation("CapQuyens");
                });

            modelBuilder.Entity("ChucvuPhanquyen.Models.NhomChucVu", b =>
                {
                    b.Navigation("ChucVus");
                });

            modelBuilder.Entity("ChucvuPhanquyen.Models.NhomQuyenTruyCap", b =>
                {
                    b.Navigation("QuyenTruyCaps");
                });

            modelBuilder.Entity("ChucvuPhanquyen.Models.Quyen", b =>
                {
                    b.Navigation("QuyenTruyCaps");
                });

            modelBuilder.Entity("ChucvuPhanquyen.Models.QuyenTruyCap", b =>
                {
                    b.Navigation("CapQuyens");
                });
#pragma warning restore 612, 618
        }
    }
}
