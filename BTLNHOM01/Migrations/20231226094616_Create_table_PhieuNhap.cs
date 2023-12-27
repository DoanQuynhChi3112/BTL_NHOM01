using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM01.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_PhieuNhap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaNV",
                table: "phieuxuats");

            migrationBuilder.DropColumn(
                name: "MaNV",
                table: "PhieuNhaps");

            migrationBuilder.CreateIndex(
                name: "IX_phieuxuats_DonHangID",
                table: "phieuxuats",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX_phieuxuats_TenHang",
                table: "phieuxuats",
                column: "TenHang");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_TenHang",
                table: "PhieuNhaps",
                column: "TenHang");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_DanhMucHangs_TenHang",
                table: "PhieuNhaps",
                column: "TenHang",
                principalTable: "DanhMucHangs",
                principalColumn: "MaHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuxuats_DanhMucHangs_TenHang",
                table: "phieuxuats",
                column: "TenHang",
                principalTable: "DanhMucHangs",
                principalColumn: "MaHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phieuxuats_DonHangs_DonHangID",
                table: "phieuxuats",
                column: "DonHangID",
                principalTable: "DonHangs",
                principalColumn: "DonHangID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_DanhMucHangs_TenHang",
                table: "PhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuxuats_DanhMucHangs_TenHang",
                table: "phieuxuats");

            migrationBuilder.DropForeignKey(
                name: "FK_phieuxuats_DonHangs_DonHangID",
                table: "phieuxuats");

            migrationBuilder.DropIndex(
                name: "IX_phieuxuats_DonHangID",
                table: "phieuxuats");

            migrationBuilder.DropIndex(
                name: "IX_phieuxuats_TenHang",
                table: "phieuxuats");

            migrationBuilder.DropIndex(
                name: "IX_PhieuNhaps_TenHang",
                table: "PhieuNhaps");

            migrationBuilder.AddColumn<string>(
                name: "MaNV",
                table: "phieuxuats",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaNV",
                table: "PhieuNhaps",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
