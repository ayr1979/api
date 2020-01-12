using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class joey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "alarmsysteminfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alarmsystempasswords",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "audioinfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "billingaddress",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "buildingcity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "buildingpostal",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "buildingstreet",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cardaccessinfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cardaccesspasswords",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "credittermsemail",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "credittersaddress",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "doorentryinfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firealarminfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "monitoringinfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nursecallinfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "owneremail",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "propertymgmtaddress",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "propertymgmtemail",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "schoolpaginginfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "videosurveillanceinfo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "videosurveillancepasswords",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alarmsysteminfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "alarmsystempasswords",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "audioinfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "billingaddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "buildingcity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "buildingpostal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "buildingstreet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "cardaccessinfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "cardaccesspasswords",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "credittermsemail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "credittersaddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "doorentryinfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "firealarminfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "monitoringinfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nursecallinfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "owneremail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "propertymgmtaddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "propertymgmtemail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "schoolpaginginfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "videosurveillanceinfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "videosurveillancepasswords",
                table: "AspNetUsers");
        }
    }
}
