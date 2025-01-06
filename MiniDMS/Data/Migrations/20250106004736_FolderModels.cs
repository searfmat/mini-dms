using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniDMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class FolderModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Document",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFolder",
                table: "Document",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Document",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentId",
                table: "Document",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Document_DocumentId",
                table: "Document",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Document_DocumentId",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_DocumentId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "IsFolder",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Document");
        }
    }
}
