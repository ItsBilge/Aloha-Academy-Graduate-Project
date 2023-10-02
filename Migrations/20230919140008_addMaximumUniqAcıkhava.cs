using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aloha_Academy_Graduate_Project.Migrations
{
    public partial class addMaximumUniqAcıkhava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maximum_Uniq_Acıkhava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticketprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maximum_Uniq_Acıkhava", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maximum_Uniq_Acıkhava_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maximum_Uniq_Acıkhava_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maximum_Uniq_Acıkhava_CategoryId",
                table: "Maximum_Uniq_Acıkhava",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Maximum_Uniq_Acıkhava_LocationId",
                table: "Maximum_Uniq_Acıkhava",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maximum_Uniq_Acıkhava");
        }
    }
}
