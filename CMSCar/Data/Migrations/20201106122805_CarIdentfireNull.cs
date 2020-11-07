using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class CarIdentfireNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorCar_Car_CarId",
                table: "ColorCar");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationCar_Car_CarId",
                table: "SpecificationCar");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "SpecificationCar",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "ColorCar",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorCar_Car_CarId",
                table: "ColorCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationCar_Car_CarId",
                table: "SpecificationCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorCar_Car_CarId",
                table: "ColorCar");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationCar_Car_CarId",
                table: "SpecificationCar");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "SpecificationCar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "ColorCar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorCar_Car_CarId",
                table: "ColorCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationCar_Car_CarId",
                table: "SpecificationCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
