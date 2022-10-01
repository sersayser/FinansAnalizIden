using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class rasyo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NetIsletmeSermayesi",
                table: "RasyoModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetIsletmeSermayesi",
                table: "RasyoModels");
        }
    }
}
