﻿// <auto-generated />
using System;
using File.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace File.Migrations
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

            modelBuilder.Entity("File.Models.Tep", b =>
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

                    b.Property<DateTime>("NgayUpload")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenTep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TepId");

                    b.ToTable("Teps");
                });

            modelBuilder.Entity("File.Models.TepCu", b =>
                {
                    b.Property<int>("TepcuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TepcuId"));

                    b.Property<byte[]>("Dulieu")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("NgayChinhXua")
                        .HasColumnType("datetime2");

                    b.Property<string>("TacDong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenTep")
                        .HasColumnType("int");

                    b.Property<int>("TepID")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("TepcuId");

                    b.HasIndex("TepID");

                    b.ToTable("TepCus");
                });

            modelBuilder.Entity("File.Models.TepCu", b =>
                {
                    b.HasOne("File.Models.Tep", "Tep")
                        .WithMany("tepCu")
                        .HasForeignKey("TepID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tep");
                });

            modelBuilder.Entity("File.Models.Tep", b =>
                {
                    b.Navigation("tepCu");
                });
#pragma warning restore 612, 618
        }
    }
}