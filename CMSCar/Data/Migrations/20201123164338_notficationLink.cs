using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class notficationLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotficationLink",
                table: "Notifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotficationLink",
                table: "Notifications");
        }
    }
}
