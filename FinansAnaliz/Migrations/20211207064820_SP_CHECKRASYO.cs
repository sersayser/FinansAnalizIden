using Microsoft.EntityFrameworkCore.Migrations;

namespace FinansAnaliz.Migrations
{
    public partial class SP_CHECKRASYO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CHECKRASYO]
@rasyoField AS VARCHAR(100) = 'CariOran',
@operant as VARCHAR(10) = '>',
@esikDeger as VARCHAR(10) = '3.05',
@CompanyName as VARCHAR(30) = N'TEST AGR',
@Donem as VARCHAR(10) = '2020-01-31'

AS
BEGIN
    Declare @mystring varchar(max) = 'select ' +  @rasyoField + ' from [u0366514_Fintech].[dbo].[RasyoModels] where  CompanyName= ''' + @CompanyName + ''' and Donem= ''' + @Donem + ''' and ' +  @rasyoField+'>'''+@esikDeger+''''
    exec (@mystring)

END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
