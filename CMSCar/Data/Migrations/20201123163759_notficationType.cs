using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class notficationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotficationType",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotficationType",
                table: "Notifications");
        }
    }
}
