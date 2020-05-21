using Microsoft.EntityFrameworkCore.Migrations;

namespace PartesCampAPI.Migrations
{
    public partial class facturada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Facturada",
                table: "Tasks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facturada",
                table: "Tasks");
        }
    }
}
