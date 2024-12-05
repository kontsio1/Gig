using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigApp.Migrations
{
    /// <inheritdoc />
    public partial class UsersTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GigUsers",
                table: "GigUsers");

            migrationBuilder.RenameTable(
                name: "GigUsers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "GigUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GigUsers",
                table: "GigUsers",
                column: "Id");
        }
    }
}
