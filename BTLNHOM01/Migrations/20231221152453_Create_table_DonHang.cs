using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM01.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_DonHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    PassWord = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucHangs",
                columns: table => new
                {
                    MaHang = table.Column<string>(type: "TEXT", nullable: false),
                    TenHang = table.Column<string>(type: "TEXT", nullable: false),
                    DonViTinh = table.Column<string>(type: "TEXT", nullable: false),
                    SoLuong = table.Column<string>(type: "TEXT", nullable: false),
                    GiaSP = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucHangs", x => x.MaHang);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "TEXT", nullable: false),
                    TenKH = table.Column<string>(type: "TEXT", nullable: false),
                    DiachiKH = table.Column<string>(type: "TEXT", nullable: false),
                    SoDT = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    SoDT = table.Column<string>(type: "TEXT", nullable: false),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "DonHangs",
                columns: table => new
                {
                    DonHangID = table.Column<string>(type: "TEXT", nullable: false),
                    MaHang = table.Column<string>(type: "TEXT", nullable: false),
                    MaKH = table.Column<string>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaNV = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangs", x => x.DonHangID);
                    table.ForeignKey(
                        name: "FK_DonHangs_DanhMucHangs_MaHang",
                        column: x => x.MaHang,
                        principalTable: "DanhMucHangs",
                        principalColumn: "MaHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangs_KhachHangs_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangs_NhanViens_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    DonHangID = table.Column<string>(type: "TEXT", nullable: false),
                    TenHang = table.Column<string>(type: "TEXT", nullable: false),
                    Soluong = table.Column<int>(type: "INTEGER", nullable: false),
                    thanhtien = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaytao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhap", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_PhieuNhap_DonHangs_DonHangID",
                        column: x => x.DonHangID,
                        principalTable: "DonHangs",
                        principalColumn: "DonHangID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phieuxuat",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    DonHangID = table.Column<string>(type: "TEXT", nullable: false),
                    TenHang = table.Column<string>(type: "TEXT", nullable: false),
                    Soluong = table.Column<int>(type: "INTEGER", nullable: false),
                    thanhtien = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaytao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuxuat", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_phieuxuat_DonHangs_DonHangID",
                        column: x => x.DonHangID,
                        principalTable: "DonHangs",
                        principalColumn: "DonHangID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_MaHang",
                table: "DonHangs",
                column: "MaHang");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_MaKH",
                table: "DonHangs",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_DonHangs_MaNV",
                table: "DonHangs",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_DonHangID",
                table: "PhieuNhap",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX_phieuxuat_DonHangID",
                table: "phieuxuat",
                column: "DonHangID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "phieuxuat");

            migrationBuilder.DropTable(
                name: "DonHangs");

            migrationBuilder.DropTable(
                name: "DanhMucHangs");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
