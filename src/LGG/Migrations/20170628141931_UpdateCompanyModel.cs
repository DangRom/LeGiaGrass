using Microsoft.EntityFrameworkCore.Migrations;

namespace LGG.Migrations
{
    public partial class UpdateCompanyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Company",
                maxLength: 254,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Company",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportEmail",
                table: "Company",
                maxLength: 254,
                nullable: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "SupportEmail",
                table: "Company");
        }
    }
}
