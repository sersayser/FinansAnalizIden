using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class settingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAlertTeminatEnds = table.Column<bool>(type: "bit", nullable: false),
                    AlertTeminatRemainingDay = table.Column<int>(type: "int", nullable: false),
                    IsAlertRuleWarning = table.Column<bool>(type: "bit", nullable: false),
                    ExtraEmail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraEmail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraEmail3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsClientShowBook = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
