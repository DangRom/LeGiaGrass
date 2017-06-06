using Microsoft.EntityFrameworkCore.Migrations;

namespace LGG.Migrations
{
    public partial class RefactorCompanyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TermsOfUseId",
                table: "Company",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PrivacyId",
                table: "Company",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AboutId",
                table: "Company",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TermsOfUseId",
                table: "Company",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrivacyId",
                table: "Company",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AboutId",
                table: "Company",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
