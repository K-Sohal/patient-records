using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class ConcernClassUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Concerns__Patien__286302EC",
                table: "Concerns");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Patient_PatientId1",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_PatientId1",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Patient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patient",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "ConcernId1",
                table: "Concerns",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concerns_ConcernId1",
                table: "Concerns",
                column: "ConcernId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Concerns_Concerns_ConcernId1",
                table: "Concerns",
                column: "ConcernId1",
                principalTable: "Concerns",
                principalColumn: "ConcernID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Concerns_Patient_PatientID",
                table: "Concerns",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concerns_Concerns_ConcernId1",
                table: "Concerns");

            migrationBuilder.DropForeignKey(
                name: "FK_Concerns_Patient_PatientID",
                table: "Concerns");

            migrationBuilder.DropIndex(
                name: "IX_Concerns_ConcernId1",
                table: "Concerns");

            migrationBuilder.DropColumn(
                name: "ConcernId1",
                table: "Concerns");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patient",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PatientId1",
                table: "Patient",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK__Concerns__Patien__286302EC",
                table: "Concerns",
                column: "PatientID",
                principalTable: "Concerns",
                principalColumn: "ConcernID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Patient_PatientId1",
                table: "Patient",
                column: "PatientId1",
                principalTable: "Patient",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
