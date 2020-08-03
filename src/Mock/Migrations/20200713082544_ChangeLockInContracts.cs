using Microsoft.EntityFrameworkCore.Migrations;

namespace Mock.Migrations
{
    public partial class ChangeLockInContracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LockInPeriod",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "LockInPeriod",
                table: "Contracts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
