using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HastaneRandevuSistemiAPI.Migrations
{
    /// <inheritdoc />
    public partial class maybebeforefinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPatient");

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("5d170c95-499d-4e58-97fa-c7a2115e0227"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("88b48b4a-fd05-4269-a7ae-c229bbe3d96b"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("cc28dcf7-4ae9-4de6-af01-3386f79fae92"));

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "Branch", "DoctorId", "Name", "PatientTc", "Surname", "Title" },
                values: new object[,]
                {
                    { new Guid("7709fb74-959f-47a7-b2e0-5e94e48f99d2"), new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, null, "34567890123", null, null },
                    { new Guid("e00e76ef-1835-47c4-9e24-50e9b4a97525"), new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, null, "23456789012", null, null },
                    { new Guid("fda67a02-94db-4702-b16d-c063e36168bd"), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null, "12345678901", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("7709fb74-959f-47a7-b2e0-5e94e48f99d2"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("e00e76ef-1835-47c4-9e24-50e9b4a97525"));

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: new Guid("fda67a02-94db-4702-b16d-c063e36168bd"));

            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientTc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.DoctorId, x.PatientTc });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Patients_PatientTc",
                        column: x => x.PatientTc,
                        principalTable: "Patients",
                        principalColumn: "Tc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "Branch", "DoctorId", "Name", "PatientTc", "Surname", "Title" },
                values: new object[,]
                {
                    { new Guid("5d170c95-499d-4e58-97fa-c7a2115e0227"), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null, "12345678901", null, null },
                    { new Guid("88b48b4a-fd05-4269-a7ae-c229bbe3d96b"), new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, null, "34567890123", null, null },
                    { new Guid("cc28dcf7-4ae9-4de6-af01-3386f79fae92"), new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, null, "23456789012", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientTc",
                table: "DoctorPatient",
                column: "PatientTc");
        }
    }
}
