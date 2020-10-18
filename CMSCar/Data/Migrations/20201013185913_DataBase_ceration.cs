using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCar.Data.Migrations
{
    public partial class DataBase_ceration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "CallUs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Massege = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CityAr = table.Column<string>(nullable: false),
                    CityEn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCash",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameCompany = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    NamePerson = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCash", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyFinance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameCompany = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    NamePerson = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CompanyActivity = table.Column<string>(nullable: false),
                    CompanyAge = table.Column<int>(nullable: false),
                    Bank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyFinance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FininceSide",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FininceSide", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCash",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CarName = table.Column<string>(nullable: false),
                    Price = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Salary = table.Column<float>(nullable: true),
                    Commitment = table.Column<float>(nullable: true),
                    Loan = table.Column<bool>(nullable: true),
                    FirstPay = table.Column<int>(nullable: true),
                    LastPay = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    WorkSector = table.Column<string>(nullable: true),
                    Bank = table.Column<int>(nullable: true),
                    licenseStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCash", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    FacebookUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true),
                    InstagramUrl = table.Column<string>(nullable: true),
                    LinkedInUrl = table.Column<string>(nullable: true),
                    YoutubeUrl = table.Column<string>(nullable: true),
                    SnapchatUrl = table.Column<string>(nullable: true),
                    WhatsappNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    SmallLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    DescriptionAr = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    QuestionAr = table.Column<string>(nullable: false),
                    QuestionEn = table.Column<string>(nullable: false),
                    AnswerAr = table.Column<string>(nullable: false),
                    AnswerEn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    DescrptionAr = table.Column<string>(nullable: true),
                    DescrptionEn = table.Column<string>(nullable: true),
                    PriceBeforeDiscount = table.Column<float>(nullable: false),
                    PriceAfterDiscount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    WhyUSAr = table.Column<string>(nullable: true),
                    WhyUSEn = table.Column<string>(nullable: true),
                    OrderAr = table.Column<string>(nullable: true),
                    OrderEn = table.Column<string>(nullable: true),
                    OurPrice = table.Column<string>(nullable: true),
                    OurSponsers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhoWeAre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    WhoWeAreAr = table.Column<string>(nullable: true),
                    WhoWeAreEn = table.Column<string>(nullable: true),
                    OurGoalsAr = table.Column<string>(nullable: true),
                    OurGoalsEn = table.Column<string>(nullable: true),
                    OurMassegeAr = table.Column<string>(nullable: true),
                    OurMassegeEn = table.Column<string>(nullable: true),
                    TermConditionAr = table.Column<string>(nullable: true),
                    TermConditionEn = table.Column<string>(nullable: true),
                    policyAr = table.Column<string>(nullable: true),
                    policyEn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhoWeAre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCarType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    CarTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCarType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCarType_CarType_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "CarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    WorkingHoursAr = table.Column<string>(nullable: true),
                    WorkingHoursEn = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WhatsappNumber = table.Column<string>(nullable: true),
                    MapLink = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarOrderCash",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameCar = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CompanyCashId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOrderCash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOrderCash_CompanyCash_CompanyCashId",
                        column: x => x.CompanyCashId,
                        principalTable: "CompanyCash",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarOrderFinance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameCar = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CompanyFinanceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOrderFinance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOrderFinance_CompanyFinance_CompanyFinanceId",
                        column: x => x.CompanyFinanceId,
                        principalTable: "CompanyFinance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    MeterReading = table.Column<string>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: true),
                    NameEn = table.Column<string>(nullable: true),
                    DescriptionAr = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    PriceBeforeDiscount = table.Column<float>(nullable: false),
                    PriceAfterDiscount = table.Column<float>(nullable: false),
                    MainImage = table.Column<string>(nullable: true),
                    ShowImage = table.Column<string>(nullable: true),
                    SubCarTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_SubCarType_SubCarTypeId",
                        column: x => x.SubCarTypeId,
                        principalTable: "SubCarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImage_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorCar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureCar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferCar",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false),
                    OfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCar", x => new { x.CarId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_OfferCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferCar_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationCar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: false),
                    ColorCarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorImage_ColorCar_ColorCarId",
                        column: x => x.ColorCarId,
                        principalTable: "ColorCar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubFeatureCar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    AnswerAr = table.Column<string>(nullable: false),
                    AnswerEn = table.Column<string>(nullable: false),
                    FeatureCarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFeatureCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubFeatureCar_FeatureCar_FeatureCarId",
                        column: x => x.FeatureCarId,
                        principalTable: "FeatureCar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubSpecificationCar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameAr = table.Column<string>(nullable: false),
                    NameEn = table.Column<string>(nullable: false),
                    AnswerAr = table.Column<string>(nullable: false),
                    AnswerEn = table.Column<string>(nullable: false),
                    SpecificationCarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSpecificationCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSpecificationCar_SpecificationCar_SpecificationCarId",
                        column: x => x.SpecificationCarId,
                        principalTable: "SpecificationCar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CityId",
                table: "Branch",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_SubCarTypeId",
                table: "Car",
                column: "SubCarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarImage_CarId",
                table: "CarImage",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOrderCash_CompanyCashId",
                table: "CarOrderCash",
                column: "CompanyCashId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOrderFinance_CompanyFinanceId",
                table: "CarOrderFinance",
                column: "CompanyFinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorCar_CarId",
                table: "ColorCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorImage_ColorCarId",
                table: "ColorImage",
                column: "ColorCarId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureCar_CarId",
                table: "FeatureCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCar_OfferId",
                table: "OfferCar",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_ServiceId",
                table: "ServiceOrder",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationCar_CarId",
                table: "SpecificationCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCarType_CarTypeId",
                table: "SubCarType",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubFeatureCar_FeatureCarId",
                table: "SubFeatureCar",
                column: "FeatureCarId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSpecificationCar_SpecificationCarId",
                table: "SubSpecificationCar",
                column: "SpecificationCarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "CallUs");

            migrationBuilder.DropTable(
                name: "CarImage");

            migrationBuilder.DropTable(
                name: "CarOrderCash");

            migrationBuilder.DropTable(
                name: "CarOrderFinance");

            migrationBuilder.DropTable(
                name: "ColorImage");

            migrationBuilder.DropTable(
                name: "FininceSide");

            migrationBuilder.DropTable(
                name: "IndividualCash");

            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.DropTable(
                name: "OfferCar");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "ServiceOrder");

            migrationBuilder.DropTable(
                name: "SubFeatureCar");

            migrationBuilder.DropTable(
                name: "SubSpecificationCar");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "WhoWeAre");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CompanyCash");

            migrationBuilder.DropTable(
                name: "CompanyFinance");

            migrationBuilder.DropTable(
                name: "ColorCar");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "FeatureCar");

            migrationBuilder.DropTable(
                name: "SpecificationCar");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "SubCarType");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
