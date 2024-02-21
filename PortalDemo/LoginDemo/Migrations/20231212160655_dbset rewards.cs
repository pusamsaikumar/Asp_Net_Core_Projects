using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginDemo.Migrations
{
    public partial class dbsetrewards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lMGetRewards",
                columns: table => new
                {
                    RewardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyQtyAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasedQty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasedAmount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lMGetRewards", x => x.RewardId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lMGetRewards");
        }
    }
}
