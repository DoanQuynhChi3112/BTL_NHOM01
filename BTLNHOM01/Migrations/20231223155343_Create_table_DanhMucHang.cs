using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM01.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_DanhMucHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
