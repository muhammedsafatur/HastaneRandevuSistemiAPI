using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HastaneRandevuSistemiAPI.Migrations
{
    /// <inheritdoc />
    public partial class beforeFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "branch",
                table: "Patients",
                newName: "Branch");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "Patients",
                newName: "branch");

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                    { new Guid("7709fb74-959f-47a7-b2e0-5e94e48f99d2"), new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, null, "34567890123", null, null },
                    { new Guid("e00e76ef-1835-47c4-9e24-50e9b4a97525"), new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, null, "23456789012", null, null },
                    { new Guid("fda67a02-94db-4702-b16d-c063e36168bd"), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null, "12345678901", null, null }
                });
        }
    }
}
