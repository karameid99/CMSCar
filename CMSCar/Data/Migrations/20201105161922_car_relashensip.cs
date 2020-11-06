using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class car_relashensip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_SubCarType_SubCarTypeId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_SubCarTypeId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "SubCarTypeId",
                table: "Car");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Slider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "Slider",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarCategory",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false),
                    SubCarTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategory", x => new { x.CarId, x.SubCarTypeId });
                    table.ForeignKey(
                        name: "FK_CarCategory_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCategory_SubCarType_SubCarTypeId",
                        column: x => x.SubCarTypeId,
                        principalTable: "SubCarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCategory_SubCarTypeId",
                table: "CarCategory",
                column: "SubCarTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCategory");

            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Slider");

            migrationBuilder.AddColumn<int>(
                name: "SubCarTypeId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Car_SubCarTypeId",
                table: "Car",
                column: "SubCarTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_SubCarType_SubCarTypeId",
                table: "Car",
                column: "SubCarTypeId",
                principalTable: "SubCarType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
