using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class add_last_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRecipient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecipient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhyUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    DescrptionAr = table.Column<string>(nullable: false),
                    DescrptionEn = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    OrderBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyUs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mail");

            migrationBuilder.DropTable(
                name: "ServiceRecipient");

            migrationBuilder.DropTable(
                name: "WhyUs");
        }
    }
}
