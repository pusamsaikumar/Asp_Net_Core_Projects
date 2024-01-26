using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginDemo.Migrations
{
    public partial class addclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientProfile",
                table: "Retailers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientProfile",
                table: "Retailers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
