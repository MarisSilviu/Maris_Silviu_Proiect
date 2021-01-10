using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maris_Silviu_Proiect.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sectie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectieName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Salon = table.Column<int>(nullable: false),
                    Diagnostic = table.Column<string>(nullable: true),
                    DataInternare = table.Column<DateTime>(nullable: false),
                    MedicID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pacient_Medic_MedicID",
                        column: x => x.MedicID,
                        principalTable: "Medic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectiePacient",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientID = table.Column<int>(nullable: false),
                    SectieID = table.Column<int>(nullable: false),
                    SectieTest = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectiePacient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SectiePacient_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectiePacient_Sectie_SectieID",
                        column: x => x.SectieID,
                        principalTable: "Sectie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacient_MedicID",
                table: "Pacient",
                column: "MedicID");

            migrationBuilder.CreateIndex(
                name: "IX_SectiePacient_PacientID",
                table: "SectiePacient",
                column: "PacientID");

            migrationBuilder.CreateIndex(
                name: "IX_SectiePacient_SectieID",
                table: "SectiePacient",
                column: "SectieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectiePacient");

            migrationBuilder.DropTable(
                name: "Pacient");

            migrationBuilder.DropTable(
                name: "Sectie");

            migrationBuilder.DropTable(
                name: "Medic");
        }
    }
}
