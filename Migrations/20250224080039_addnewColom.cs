using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsCommercial.Migrations
{
    public partial class addnewColom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BKKNonBKK",
                table: "Transaksis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GTINDExp",
                table: "Transaksis",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BKKNonBKK",
                table: "Transaksis");

            migrationBuilder.DropColumn(
                name: "GTINDExp",
                table: "Transaksis");
        }
    }
}
