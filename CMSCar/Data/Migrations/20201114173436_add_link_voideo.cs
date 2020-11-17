using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class add_link_voideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkVideo",
                table: "WhoWeAre",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkVideo",
                table: "WhoWeAre");
        }
    }
}
