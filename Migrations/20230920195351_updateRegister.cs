using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aloha_Academy_Graduate_Project.Migrations
{
    public partial class updateRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Registers");
        }
    }
}
