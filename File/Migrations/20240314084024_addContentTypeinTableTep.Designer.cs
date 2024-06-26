﻿// <auto-generated />
using System;
using FileRetention.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace File.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240314084024_addContentTypeinTableTep")]
    partial class addContentTypeinTableTep
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FileRetention.Models.Tep", b =>
                {
                    b.Property<int>("TepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TepId"));

                    b.Property<byte[]>("DuLieu")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("KieuTep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenTep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.Property<string>("contentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TepId");

                    b.ToTable("Teps");
                });

            modelBuilder.Entity("FileRetention.Models.TepCu", b =>
                {
                    b.Property<int>("TepcuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TepcuId"));

                    b.Property<byte[]>("Dulieu")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Kieutep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayChinhXua")
                        .HasColumnType("datetime2");

                    b.Property<string>("TacDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TepID")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("TepcuId");

                    b.HasIndex("TepID");

                    b.ToTable("TepCus");
                });

            modelBuilder.Entity("FileRetention.Models.TepCu", b =>
                {
                    b.HasOne("FileRetention.Models.Tep", "Tep")
                        .WithMany("tepCu")
                        .HasForeignKey("TepID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tep");
                });

            modelBuilder.Entity("FileRetention.Models.Tep", b =>
                {
                    b.Navigation("tepCu");
                });
#pragma warning restore 612, 618
        }
    }
}
