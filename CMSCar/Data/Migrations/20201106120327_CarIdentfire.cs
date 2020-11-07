using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class CarIdentfire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureCar_Car_CarId",
                table: "FeatureCar");

            migrationBuilder.AddColumn<string>(
                name: "CarIdentfire",
                table: "SpecificationCar",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "FeatureCar",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CarIdentfire",
                table: "FeatureCar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarIdentfire",
                table: "ColorCar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarIdentfire",
                table: "Car",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureCar_Car_CarId",
                table: "FeatureCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureCar_Car_CarId",
                table: "FeatureCar");

            migrationBuilder.DropColumn(
                name: "CarIdentfire",
                table: "SpecificationCar");

            migrationBuilder.DropColumn(
                name: "CarIdentfire",
                table: "FeatureCar");

            migrationBuilder.DropColumn(
                name: "CarIdentfire",
                table: "ColorCar");

            migrationBuilder.DropColumn(
                name: "CarIdentfire",
                table: "Car");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "FeatureCar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureCar_Car_CarId",
                table: "FeatureCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
