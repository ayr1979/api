using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class imageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "OrderParts",
                newName: "added");

            migrationBuilder.AddColumn<string>(
                name: "photoUrl",
                table: "OrderParts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photoUrl",
                table: "OrderParts");

            migrationBuilder.RenameColumn(
                name: "added",
                table: "OrderParts",
                newName: "Created");
        }
    }
}
