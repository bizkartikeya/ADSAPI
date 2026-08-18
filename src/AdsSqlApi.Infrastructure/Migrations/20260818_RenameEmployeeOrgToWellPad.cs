using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdsSqlApi.Infrastructure.Migrations
{
    public partial class RenameEmployeeOrgToWellPad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // If existing tables Employees and Organizations exist, rename them to Wells and Pads respectively to preserve data
            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'dbo.Employees', N'U') IS NOT NULL
                BEGIN
                    EXEC sp_rename 'dbo.Employees', 'Wells'
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'dbo.Organizations', N'U') IS NOT NULL
                BEGIN
                    EXEC sp_rename 'dbo.Organizations', 'Pads'
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // revert names
            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'dbo.Wells', N'U') IS NOT NULL
                BEGIN
                    EXEC sp_rename 'dbo.Wells', 'Employees'
                END
            ");

            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'dbo.Pads', N'U') IS NOT NULL
                BEGIN
                    EXEC sp_rename 'dbo.Pads', 'Organizations'
                END
            ");
        }
    }
}
