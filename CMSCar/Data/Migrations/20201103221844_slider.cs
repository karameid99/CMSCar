using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class slider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryType",
                table: "SubCarType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    MainImage = table.Column<string>(nullable: true),
                    Image1 = table.Column<string>(nullable: true),
                    Image2 = table.Column<string>(nullable: true),
                    Image3 = table.Column<string>(nullable: true),
                    Image4 = table.Column<string>(nullable: true),
                    TitleAr = table.Column<string>(nullable: true),
                    TitleEn = table.Column<string>(nullable: true),
                    SubTitleAr = table.Column<string>(nullable: true),
                    SubTitleEn = table.Column<string>(nullable: true),
                    LinkUrl = table.Column<string>(nullable: true),
                    SliderType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "SubCarType");
        }
    }
}
