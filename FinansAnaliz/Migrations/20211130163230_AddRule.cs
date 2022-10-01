using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class AddRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {






 


            migrationBuilder.CreateTable(
                name: "RuleNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ruleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCompanyCode = table.Column<int>(type: "int", nullable: false),
                    CheckRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefrenceValue = table.Column<double>(type: "float", nullable: false),
                    IsMailSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

           
        }

    
    }
}
