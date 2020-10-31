using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class update_order_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OurPriceEn",
                table: "Titles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurSponsersEn",
                table: "Titles",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "licenseStatus",
                table: "IndividualFinance",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastPay",
                table: "IndividualFinance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FirstPay",
                table: "IndividualFinance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Bank",
                table: "IndividualFinance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Bank",
                table: "CompanyFinance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OurPriceEn",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "OurSponsersEn",
                table: "Titles");

            migrationBuilder.AlterColumn<int>(
                name: "licenseStatus",
                table: "IndividualFinance",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastPay",
                table: "IndividualFinance",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "FirstPay",
                table: "IndividualFinance",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Bank",
                table: "IndividualFinance",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Bank",
                table: "CompanyFinance",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
