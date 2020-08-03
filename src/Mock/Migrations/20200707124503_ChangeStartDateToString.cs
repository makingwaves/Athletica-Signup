using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mock.Migrations
{
    public partial class ChangeStartDateToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Memberships",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Memberships",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
