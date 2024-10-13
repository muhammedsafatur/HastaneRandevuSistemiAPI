using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HastaneRandevuSistemiAPI.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientTc",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Patients_PatientTc",
                table: "DoctorPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Tc",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Tc");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "AppointmentId", "Branch", "Name", "Role", "Surname" },
                values: new object[,]
                {
                    { 1, new Guid("00000000-0000-0000-0000-000000000000"), 4, "Ali", 1, "Yılmaz" },
                    { 2, new Guid("00000000-0000-0000-0000-000000000000"), 1, "Ayşe", 4, "Kara" },
                    { 3, new Guid("00000000-0000-0000-0000-000000000000"), 5, "Mehmet", 0, "Demir" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Tc", "Email", "Id", "Name", "Phone", "Surname", "branch" },
                values: new object[,]
                {
                    { "12345678901", "zeynep.aydin@example.com", null, "Zeynep", "5551234567", "Aydın", 0 },
                    { "23456789012", "emre.koc@example.com", null, "Emre", "5557654321", "Koç", 0 },
                    { "34567890123", "elif.polat@example.com", null, "Elif", "5559876543", "Polat", 0 }
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
                name: "IX_Patients_Tc",
                table: "Patients",
                column: "Tc",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientTc",
                table: "Appointments",
                column: "PatientTc",
                principalTable: "Patients",
                principalColumn: "Tc");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Patients_PatientTc",
                table: "DoctorPatient",
                column: "PatientTc",
                principalTable: "Patients",
                principalColumn: "Tc",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientTc",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Patients_PatientTc",
                table: "DoctorPatient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Tc",
                table: "Patients");

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

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Tc",
                keyValue: "12345678901");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Tc",
                keyValue: "23456789012");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Tc",
                keyValue: "34567890123");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tc",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientTc",
                table: "Appointments",
                column: "PatientTc",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Patients_PatientTc",
                table: "DoctorPatient",
                column: "PatientTc",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
