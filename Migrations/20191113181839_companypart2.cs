using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class companypart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "CompanyParts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CompanyParts");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "CompanyParts",
                newName: "Added");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Added",
                table: "CompanyParts",
                newName: "OrderDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "CompanyParts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CompanyParts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
