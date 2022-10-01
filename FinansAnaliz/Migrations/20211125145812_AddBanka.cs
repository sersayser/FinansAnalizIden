using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class AddBanka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BayiId",
                table: "Teminats");

            migrationBuilder.DropColumn(
                name: "Miktar",
                table: "Teminats");

            migrationBuilder.AlterColumn<string>(
                name: "TeminatNo",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BitisTarihi",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Banka",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlinanTeminat",
                table: "Teminats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnaTeminat",
                table: "Teminats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MainCompanyCode",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tutar",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bankalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankalar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bankalar");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Teminats");

            migrationBuilder.DropColumn(
                name: "IsAlinanTeminat",
                table: "Teminats");

            migrationBuilder.DropColumn(
                name: "IsAnaTeminat",
                table: "Teminats");

            migrationBuilder.DropColumn(
                name: "MainCompanyCode",
                table: "Teminats");

            migrationBuilder.DropColumn(
                name: "Tutar",
                table: "Teminats");

            migrationBuilder.AlterColumn<string>(
                name: "TeminatNo",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BitisTarihi",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Banka",
                table: "Teminats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BayiId",
                table: "Teminats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Miktar",
                table: "Teminats",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
