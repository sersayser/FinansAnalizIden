using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class rules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vergi_VOKMarji",
                table: "RasyoModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Vergi_VOKMarji",
                table: "RasyoModels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
