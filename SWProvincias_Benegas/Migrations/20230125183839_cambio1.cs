using Microsoft.EntityFrameworkCore.Migrations;

namespace SWProvincias_Benegas.Migrations
{
    public partial class cambio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Provincia_ClinicaID",
                table: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_Ciudad_ClinicaID",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "ClinicaID",
                table: "Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_ProvinciaId",
                table: "Ciudad",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Provincia_ProvinciaId",
                table: "Ciudad",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Provincia_ProvinciaId",
                table: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_Ciudad_ProvinciaId",
                table: "Ciudad");

            migrationBuilder.AddColumn<int>(
                name: "ClinicaID",
                table: "Ciudad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_ClinicaID",
                table: "Ciudad",
                column: "ClinicaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Provincia_ClinicaID",
                table: "Ciudad",
                column: "ClinicaID",
                principalTable: "Provincia",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
