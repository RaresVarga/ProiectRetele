using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRetele.Migrations
{
    public partial class eroareMasini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Masina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Masina_ClientID",
                table: "Masina",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masina_Client_ClientID",
                table: "Masina",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masina_Client_ClientID",
                table: "Masina");

            migrationBuilder.DropIndex(
                name: "IX_Masina_ClientID",
                table: "Masina");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Masina");
        }
    }
}
