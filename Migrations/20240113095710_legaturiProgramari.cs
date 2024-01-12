using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRetele.Migrations
{
    public partial class legaturiProgramari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasinaID",
                table: "Programare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MecanicID",
                table: "Programare",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programare_MasinaID",
                table: "Programare",
                column: "MasinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_MecanicID",
                table: "Programare",
                column: "MecanicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Masina_MasinaID",
                table: "Programare",
                column: "MasinaID",
                principalTable: "Masina",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Mecanic_MecanicID",
                table: "Programare",
                column: "MecanicID",
                principalTable: "Mecanic",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Masina_MasinaID",
                table: "Programare");

            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Mecanic_MecanicID",
                table: "Programare");

            migrationBuilder.DropIndex(
                name: "IX_Programare_MasinaID",
                table: "Programare");

            migrationBuilder.DropIndex(
                name: "IX_Programare_MecanicID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "MasinaID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "MecanicID",
                table: "Programare");
        }
    }
}
