using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniDMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Files : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Document_DocumentId",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Document",
                newName: "FileId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_DocumentId",
                table: "Document",
                newName: "IX_Document_FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Document_FileId",
                table: "Document",
                column: "FileId",
                principalTable: "Document",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Document_FileId",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "Document",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_FileId",
                table: "Document",
                newName: "IX_Document_DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Document_DocumentId",
                table: "Document",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id");
        }
    }
}
