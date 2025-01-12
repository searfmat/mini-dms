using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniDMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class FileRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditRecord_Document_FileId",
                table: "AuditRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Document_FileId",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "Document",
                newName: "FileModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_FileId",
                table: "Document",
                newName: "IX_Document_FileModelId");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "AuditRecord",
                newName: "FileModelId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditRecord_FileId",
                table: "AuditRecord",
                newName: "IX_AuditRecord_FileModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditRecord_Document_FileModelId",
                table: "AuditRecord",
                column: "FileModelId",
                principalTable: "Document",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Document_FileModelId",
                table: "Document",
                column: "FileModelId",
                principalTable: "Document",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditRecord_Document_FileModelId",
                table: "AuditRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Document_FileModelId",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "FileModelId",
                table: "Document",
                newName: "FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_FileModelId",
                table: "Document",
                newName: "IX_Document_FileId");

            migrationBuilder.RenameColumn(
                name: "FileModelId",
                table: "AuditRecord",
                newName: "FileId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditRecord_FileModelId",
                table: "AuditRecord",
                newName: "IX_AuditRecord_FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditRecord_Document_FileId",
                table: "AuditRecord",
                column: "FileId",
                principalTable: "Document",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Document_FileId",
                table: "Document",
                column: "FileId",
                principalTable: "Document",
                principalColumn: "Id");
        }
    }
}
