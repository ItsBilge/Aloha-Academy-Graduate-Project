using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aloha_Academy_Graduate_Project.Migrations
{
    public partial class updateNewRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Registers",
                newName: "RePassword");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Registers",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Registers",
                newName: "Birthdate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RePassword",
                table: "Registers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Registers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Registers",
                newName: "Gender");
        }
    }
}
