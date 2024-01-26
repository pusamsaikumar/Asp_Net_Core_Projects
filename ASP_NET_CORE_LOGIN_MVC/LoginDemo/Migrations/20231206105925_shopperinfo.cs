using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginDemo.Migrations
{
    public partial class shopperinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopperInfos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LASTNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PREFERREDSTORE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USERDETAILID = table.Column<int>(type: "int", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopperInfos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopperInfos");
        }
    }
}
