using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class edit_order_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "City",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "Commitment",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "FirstPay",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "LastPay",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "Loan",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "WorkSector",
                table: "IndividualCash");

            migrationBuilder.DropColumn(
                name: "licenseStatus",
                table: "IndividualCash");

            migrationBuilder.CreateTable(
                name: "IndividualFinance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CarName = table.Column<string>(nullable: false),
                    Price = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Salary = table.Column<float>(nullable: false),
                    Commitment = table.Column<float>(nullable: false),
                    Loan = table.Column<bool>(nullable: false),
                    FirstPay = table.Column<int>(nullable: false),
                    LastPay = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    WorkSector = table.Column<string>(nullable: false),
                    Bank = table.Column<int>(nullable: false),
                    licenseStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualFinance", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualFinance");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "IndividualCash",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Bank",
                table: "IndividualCash",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "IndividualCash",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Commitment",
                table: "IndividualCash",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstPay",
                table: "IndividualCash",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastPay",
                table: "IndividualCash",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Loan",
                table: "IndividualCash",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "IndividualCash",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkSector",
                table: "IndividualCash",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "licenseStatus",
                table: "IndividualCash",
                type: "int",
                nullable: true);
        }
    }
}
