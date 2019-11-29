using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class companypart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOrderPart");

            migrationBuilder.CreateTable(
                name: "CompanyParts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    OrderPartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyParts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyParts_UserId",
                table: "CompanyParts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyParts");

            migrationBuilder.CreateTable(
                name: "UserOrderPart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderPartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrderPart_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderPart_UserId",
                table: "UserOrderPart",
                column: "UserId");
        }
    }
}
