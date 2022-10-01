using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class rasyo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.RenameColumn(
                name: "NetKarMarji_EBITDAmarji",
                table: "RasyoModels",
                newName: "Vergi_NetSatisOrani");

            migrationBuilder.AddColumn<decimal>(
                name: "EBITDA_Marji",
                table: "RasyoModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FAVÖK_EBITDA",
                table: "RasyoModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Satıslarinİcerisindekiİhracat",
                table: "RasyoModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EBITDA_Marji",
                table: "RasyoModels");

            migrationBuilder.DropColumn(
                name: "FAVÖK_EBITDA",
                table: "RasyoModels");

            migrationBuilder.DropColumn(
                name: "Satıslarinİcerisindekiİhracat",
                table: "RasyoModels");



            migrationBuilder.RenameColumn(
                name: "Vergi_NetSatisOrani",
                table: "RasyoModels",
                newName: "NetKarMarji_EBITDAmarji");
        }
    }
}
