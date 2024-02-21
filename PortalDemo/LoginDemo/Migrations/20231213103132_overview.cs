using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginDemo.Migrations
{
    public partial class overview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoyalityId",
                table: "LoyalityMembers",
                newName: "LoyalityID");

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TOTALBASKETAMOUNT = table.Column<double>(type: "float", nullable: false),
                    LOYALTYID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STOREID = table.Column<int>(type: "int", nullable: false),
                    STORENAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasketJSON = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCRImpressionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewscategoryID = table.Column<int>(type: "int", nullable: false),
                    PreferredStore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptIns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redemption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedemptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewscategoryID = table.Column<int>(type: "int", nullable: false),
                    PreferredStore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RDJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redemption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEMBERNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REWARDTITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REWARDSCOUNT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BARCODEVALUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USERDETAILID = table.Column<int>(type: "int", nullable: false),
                    STOREID = table.Column<int>(type: "int", nullable: false),
                    STORENAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SIGNUPDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegister", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropTable(
                name: "OptIns");

            migrationBuilder.DropTable(
                name: "Redemption");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "UserRegister");

            migrationBuilder.RenameColumn(
                name: "LoyalityID",
                table: "LoyalityMembers",
                newName: "LoyalityId");
        }
    }
}
