using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class FixedSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FixedSlider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Layer1 = table.Column<string>(nullable: true),
                    Layer2 = table.Column<string>(nullable: true),
                    Layer3 = table.Column<string>(nullable: true),
                    Layer4 = table.Column<string>(nullable: true),
                    Layer5 = table.Column<string>(nullable: true),
                    Layer6 = table.Column<string>(nullable: true),
                    Layer7 = table.Column<string>(nullable: true),
                    Layer8 = table.Column<string>(nullable: true),
                    Layer9 = table.Column<string>(nullable: true),
                    Layer10 = table.Column<string>(nullable: true),
                    Layer11 = table.Column<string>(nullable: true),
                    Layer12 = table.Column<string>(nullable: true),
                    Layer13 = table.Column<string>(nullable: true),
                    Layer14 = table.Column<string>(nullable: true),
                    Layer15 = table.Column<string>(nullable: true),
                    Layer16 = table.Column<string>(nullable: true),
                    Layer17 = table.Column<string>(nullable: true),
                    Layer18 = table.Column<string>(nullable: true),
                    Layer19 = table.Column<string>(nullable: true),
                    Layer20 = table.Column<string>(nullable: true),
                    MainLayer = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FixedSliders = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedSlider", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixedSlider");
        }
    }
}
