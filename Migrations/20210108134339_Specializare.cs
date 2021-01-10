using Microsoft.EntityFrameworkCore.Migrations;

namespace Maris_Silviu_Proiect.Migrations
{
    public partial class Specializare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectieTest",
                table: "SectiePacient");

            migrationBuilder.AddColumn<string>(
                name: "MedicSpecializare",
                table: "Medic",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicSpecializare",
                table: "Medic");

            migrationBuilder.AddColumn<int>(
                name: "SectieTest",
                table: "SectiePacient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
