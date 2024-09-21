using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Create_table_Sinhvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Sinhvien",
                newName: "diachi");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Sinhvien",
                newName: "Hoten");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Sinhvien",
                newName: "nguoi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "diachi",
                table: "Sinhvien",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Hoten",
                table: "Sinhvien",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "nguoi",
                table: "Sinhvien",
                newName: "PersonId");
        }
    }
}
