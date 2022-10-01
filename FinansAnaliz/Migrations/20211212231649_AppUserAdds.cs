using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class AppUserAdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlertTeminatRemainingDay",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraEmail1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraEmail2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraEmail3",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlertRuleWarning",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlertTeminatEnds",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClientShowBook",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertTeminatRemainingDay",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExtraEmail1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExtraEmail2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExtraEmail3",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAlertRuleWarning",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAlertTeminatEnds",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsClientShowBook",
                table: "AspNetUsers");
        }
    }
}
