using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlesCotas.Infra.Data.Migrations
{
    public partial class gabinete_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Gabinetes_IDGabinete",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "IDGabinete",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Gabinetes_IDGabinete",
                table: "Usuarios",
                column: "IDGabinete",
                principalTable: "Gabinetes",
                principalColumn: "IDGabinete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Gabinetes_IDGabinete",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "IDGabinete",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Gabinetes_IDGabinete",
                table: "Usuarios",
                column: "IDGabinete",
                principalTable: "Gabinetes",
                principalColumn: "IDGabinete",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
