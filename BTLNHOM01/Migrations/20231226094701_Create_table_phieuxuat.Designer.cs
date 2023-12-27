﻿// <auto-generated />
using System;
using BTLNHOM01.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLNHOM01.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    [Migration("20231226094701_Create_table_phieuxuat")]
    partial class Create_table_phieuxuat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("BTLNHOM01.Models.DanhMucHang", b =>
                {
                    b.Property<string>("MaHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GiaSP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SoLuong")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaHang");

                    b.ToTable("DanhMucHangs");
                });

            modelBuilder.Entity("BTLNHOM01.Models.DonHang", b =>
                {
                    b.Property<string>("DonHangID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DonHangID");

                    b.HasIndex("MaHang");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaNV");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("BTLNHOM01.Models.KhachHang", b =>
                {
                    b.Property<string>("MaKH")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiachiKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaKH");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("BTLNHOM01.Models.NhaCungCap", b =>
                {
                    b.Property<string>("MaNCC")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiachiNCC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDTNCC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNCC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNCC");

                    b.ToTable("NhaCungCaps");
                });

            modelBuilder.Entity("BTLNHOM01.Models.NhanVien", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SoDT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNV");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("BTLNHOM01.Models.PhieuNhap", b =>
                {
                    b.Property<string>("MaPN")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNCC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ngaytao")
                        .HasColumnType("TEXT");

                    b.Property<int>("Soluong")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("thanhtien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaPN");

                    b.HasIndex("MaNCC");

                    b.HasIndex("TenHang");

                    b.ToTable("PhieuNhaps");
                });

            modelBuilder.Entity("BTLNHOM01.Models.phieuxuat", b =>
                {
                    b.Property<string>("MaPX")
                        .HasColumnType("TEXT");

                    b.Property<string>("DonHangID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MaNCC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Ngaytao")
                        .HasColumnType("TEXT");

                    b.Property<int>("Soluong")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("thanhtien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaPX");

                    b.HasIndex("DonHangID");

                    b.HasIndex("MaNCC");

                    b.HasIndex("TenHang");

                    b.ToTable("phieuxuats");
                });

            modelBuilder.Entity("BTLNHOM01.Models.DonHang", b =>
                {
                    b.HasOne("BTLNHOM01.Models.DanhMucHang", "DanhMucHang")
                        .WithMany()
                        .HasForeignKey("MaHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNHOM01.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNHOM01.Models.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucHang");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("BTLNHOM01.Models.PhieuNhap", b =>
                {
                    b.HasOne("BTLNHOM01.Models.NhaCungCap", "NhaCungCap")
                        .WithMany()
                        .HasForeignKey("MaNCC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNHOM01.Models.DanhMucHang", "DanhMucHang")
                        .WithMany()
                        .HasForeignKey("TenHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucHang");

                    b.Navigation("NhaCungCap");
                });

            modelBuilder.Entity("BTLNHOM01.Models.phieuxuat", b =>
                {
                    b.HasOne("BTLNHOM01.Models.DonHang", "DonHang")
                        .WithMany()
                        .HasForeignKey("DonHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNHOM01.Models.NhaCungCap", "NhaCungCap")
                        .WithMany()
                        .HasForeignKey("MaNCC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLNHOM01.Models.DanhMucHang", "DanhMucHang")
                        .WithMany()
                        .HasForeignKey("TenHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucHang");

                    b.Navigation("DonHang");

                    b.Navigation("NhaCungCap");
                });
#pragma warning restore 612, 618
        }
    }
}
