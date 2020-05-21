using Microsoft.EntityFrameworkCore.Migrations;

namespace PartesCampAPI.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lands_Clients_ClientID",
                table: "Lands");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lands_LandID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LandID",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "JwtID",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LandID",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ClientName",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Lands",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserID",
                table: "Clients",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserID",
                table: "Clients",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lands_Clients_ClientID",
                table: "Lands",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lands_LandID",
                table: "Tasks",
                column: "LandID",
                principalTable: "Lands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Lands_Clients_ClientID",
                table: "Lands");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Lands_LandID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "JwtID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClientName",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LandID",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "Lands",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LandID",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Lands_Clients_ClientID",
                table: "Lands",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Lands_LandID",
                table: "Tasks",
                column: "LandID",
                principalTable: "Lands",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
