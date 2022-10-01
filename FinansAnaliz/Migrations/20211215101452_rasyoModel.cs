using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class rasyoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FAVOK_EBITDA",
                table: "RasyoModels");

            migrationBuilder.DropColumn(
                name: "FinDurVar_DurVarOr",
                table: "RasyoModels");

            migrationBuilder.DropColumn(
                name: "NetişletmeSermayesi",
                table: "RasyoModels");

            migrationBuilder.RenameColumn(
                name: "NetIsletmeSermayesi",
                table: "RasyoModels",
                newName: "NetisletmeSermayesi");

            migrationBuilder.RenameColumn(
                name: "SatislarınIcerisindekiIhracatPayi",
                table: "RasyoModels",
                newName: "FinDurVar_DurVarOrani");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NetisletmeSermayesi",
                table: "RasyoModels",
                newName: "NetIsletmeSermayesi");

            migrationBuilder.RenameColumn(
                name: "FinDurVar_DurVarOrani",
                table: "RasyoModels",
                newName: "SatislarınIcerisindekiIhracatPayi");

            migrationBuilder.AddColumn<decimal>(
                name: "FAVOK_EBITDA",
                table: "RasyoModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinDurVar_DurVarOr",
                table: "RasyoModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetişletmeSermayesi",
                table: "RasyoModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
