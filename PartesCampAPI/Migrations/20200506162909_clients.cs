using Microsoft.EntityFrameworkCore.Migrations;

namespace PartesCampAPI.Migrations
{
    public partial class clients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lands_Owners_ClientID",
                table: "Lands");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Users_UserID",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_Owners_UserID",
                table: "Clients",
                newName: "IX_Clients_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserID",
                table: "Clients",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lands_Clients_ClientID",
                table: "Lands",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserID",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Lands_Clients_ClientID",
                table: "Lands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Owners");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_UserID",
                table: "Owners",
                newName: "IX_Owners_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lands_Owners_ClientID",
                table: "Lands",
                column: "ClientID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Users_UserID",
                table: "Owners",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
