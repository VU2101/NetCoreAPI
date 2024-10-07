using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Nhapvao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Dangnhap",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Dangnhap",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Masinhvien",
                table: "Dangnhap",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Dangnhap");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Dangnhap");

            migrationBuilder.DropColumn(
                name: "Masinhvien",
                table: "Dangnhap");
        }
    }
}
