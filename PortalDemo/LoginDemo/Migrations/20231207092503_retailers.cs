using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginDemo.Migrations
{
    public partial class retailers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Retailers",
                columns: table => new
                {
                    RSAClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AndriodArn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IphoneArn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllUsersArn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DBName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PushNOtificationEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsEditView = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retailers", x => x.RSAClientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retailers");
        }
    }
}
