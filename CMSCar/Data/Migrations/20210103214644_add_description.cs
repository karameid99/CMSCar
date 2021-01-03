using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class add_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubDescriptionAr",
                table: "Car",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubDescriptionEn",
                table: "Car",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubDescriptionAr",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "SubDescriptionEn",
                table: "Car");
        }
    }
}
