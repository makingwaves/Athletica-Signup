using Microsoft.EntityFrameworkCore.Migrations;

namespace Mock.Migrations
{
    public partial class NullableContractInstitution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LearningInstitutionId",
                table: "Contracts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LearningInstitutionId",
                table: "Contracts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
