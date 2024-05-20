﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService.Context;

#nullable disable

namespace UserService.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240518101341_adddistributors")]
    partial class adddistributors
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserService.Models.Account", b =>
                {
                    b.Property<int>("accId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("accId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("areaCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("managerID")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<int>("titleID")
                        .HasColumnType("int");

                    b.HasKey("accId");

                    b.HasIndex("areaCode");

                    b.HasIndex("managerID");

                    b.HasIndex("titleID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("UserService.Models.Area", b =>
                {
                    b.Property<string>("areaCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("areaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("areaCode");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("UserService.Models.Distributor", b =>
                {
                    b.Property<int>("disID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("disID"));

                    b.Property<string>("NumberPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("areacode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("disEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("disName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("disID");

                    b.HasIndex("areacode");

                    b.ToTable("Distributors");
                });

            modelBuilder.Entity("UserService.Models.Title", b =>
                {
                    b.Property<int>("titleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("titleID"));

                    b.Property<string>("titleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("titleID");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("UserService.Models.Account", b =>
                {
                    b.HasOne("UserService.Models.Area", "area")
                        .WithMany("accounts")
                        .HasForeignKey("areaCode");

                    b.HasOne("UserService.Models.Account", "account")
                        .WithMany("accounts")
                        .HasForeignKey("managerID");

                    b.HasOne("UserService.Models.Title", "title")
                        .WithMany("accounts")
                        .HasForeignKey("titleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");

                    b.Navigation("area");

                    b.Navigation("title");
                });

            modelBuilder.Entity("UserService.Models.Distributor", b =>
                {
                    b.HasOne("UserService.Models.Area", "area")
                        .WithMany("distributors")
                        .HasForeignKey("areacode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("area");
                });

            modelBuilder.Entity("UserService.Models.Account", b =>
                {
                    b.Navigation("accounts");
                });

            modelBuilder.Entity("UserService.Models.Area", b =>
                {
                    b.Navigation("accounts");

                    b.Navigation("distributors");
                });

            modelBuilder.Entity("UserService.Models.Title", b =>
                {
                    b.Navigation("accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
