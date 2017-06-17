using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LGG.Migrations
{
    public partial class ModifyCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Company",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurClients",
                table: "Company",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurDifference1",
                table: "Company",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurDifference2",
                table: "Company",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurDifference3",
                table: "Company",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurDifference4",
                table: "Company",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurDifference5",
                table: "Company",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurMission",
                table: "Company",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoPresentation",
                table: "Company",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhyChooseUs",
                table: "Company",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OurClients",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OurDifference1",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OurDifference2",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OurDifference3",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OurDifference4",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OurDifference5",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "OurMission",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "VideoPresentation",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "WhyChooseUs",
                table: "Company");
        }
    }
}
