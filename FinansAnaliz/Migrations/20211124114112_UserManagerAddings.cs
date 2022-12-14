using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class UserManagerAddings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClient",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainCompanyCode",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsClient",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MainCompanyCode",
                table: "AspNetUsers");
        }
    }
}
