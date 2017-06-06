using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LGG.Migrations
{
    public partial class AddCompanyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AboutId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    ArticleAboutArticleId = table.Column<int>(nullable: true),
                    ArticlePrivacyArticleId = table.Column<int>(nullable: true),
                    ArticleTermsOfUseArticleId = table.Column<int>(nullable: true),
                    Avatar = table.Column<string>(maxLength: 250, nullable: true),
                    Email = table.Column<string>(maxLength: 254, nullable: true),
                    Facebook = table.Column<string>(maxLength: 50, nullable: true),
                    Google = table.Column<string>(maxLength: 50, nullable: true),
                    Hotline = table.Column<string>(maxLength: 15, nullable: true),
                    Instagram = table.Column<string>(maxLength: 50, nullable: true),
                    LinkedIn = table.Column<string>(maxLength: 50, nullable: true),
                    Logo = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Pinterest = table.Column<string>(maxLength: 50, nullable: true),
                    PrivacyId = table.Column<int>(nullable: false),
                    Sologan = table.Column<string>(maxLength: 250, nullable: true),
                    TermsOfUseId = table.Column<int>(nullable: false),
                    TimeWork = table.Column<string>(maxLength: 250, nullable: true),
                    Twitter = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Article_ArticleAboutArticleId",
                        column: x => x.ArticleAboutArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Article_ArticlePrivacyArticleId",
                        column: x => x.ArticlePrivacyArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Company_Article_ArticleTermsOfUseArticleId",
                        column: x => x.ArticleTermsOfUseArticleId,
                        principalTable: "Article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_ArticleAboutArticleId",
                table: "Company",
                column: "ArticleAboutArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ArticlePrivacyArticleId",
                table: "Company",
                column: "ArticlePrivacyArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_ArticleTermsOfUseArticleId",
                table: "Company",
                column: "ArticleTermsOfUseArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
