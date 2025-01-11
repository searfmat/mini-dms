using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniDMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuditRecordTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditRecord_Document_FileModelId",
                table: "AuditRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditRecord",
                table: "AuditRecord");

            migrationBuilder.RenameTable(
                name: "AuditRecord",
                newName: "AuditRecords");

            migrationBuilder.RenameIndex(
                name: "IX_AuditRecord_FileModelId",
                table: "AuditRecords",
                newName: "IX_AuditRecords_FileModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditRecords",
                table: "AuditRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditRecords_Document_FileModelId",
                table: "AuditRecords",
                column: "FileModelId",
                principalTable: "Document",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditRecords_Document_FileModelId",
                table: "AuditRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditRecords",
                table: "AuditRecords");

            migrationBuilder.RenameTable(
                name: "AuditRecords",
                newName: "AuditRecord");

            migrationBuilder.RenameIndex(
                name: "IX_AuditRecords_FileModelId",
                table: "AuditRecord",
                newName: "IX_AuditRecord_FileModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditRecord",
                table: "AuditRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditRecord_Document_FileModelId",
                table: "AuditRecord",
                column: "FileModelId",
                principalTable: "Document",
                principalColumn: "Id");
        }
    }
}
