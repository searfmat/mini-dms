using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniDMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class FileWhiteList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "AuditRecord",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "AuditRecord");
        }
    }
}
