using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniDMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuditRecordAddID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "AuditRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "AuditRecords");
        }
    }
}
