using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRetele.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID_Programare",
                table: "Factura",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProgramareID",
                table: "Factura",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ProgramareID",
                table: "Factura",
                column: "ProgramareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Programare_ProgramareID",
                table: "Factura",
                column: "ProgramareID",
                principalTable: "Programare",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Programare_ProgramareID",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ProgramareID",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ProgramareID",
                table: "Factura");

            migrationBuilder.AlterColumn<int>(
                name: "ID_Programare",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
