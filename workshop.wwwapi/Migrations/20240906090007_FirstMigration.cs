using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    doctorId = table.Column<int>(type: "integer", nullable: false),
                    patientId = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => new { x.doctorId, x.patientId });
                    table.ForeignKey(
                        name: "FK_appointment_doctor_doctorId",
                        column: x => x.doctorId,
                        principalTable: "doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_patient_patientId",
                        column: x => x.patientId,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "id", "fullName" },
                values: new object[] { 1, "Mayra Mahamud" });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "fullName" },
                values: new object[] { 1, "Nigel Sibbert" });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctorId", "patientId", "booking" },
                values: new object[] { 1, 1, new DateTime(2024, 9, 6, 9, 0, 7, 375, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_patientId",
                table: "appointment",
                column: "patientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
