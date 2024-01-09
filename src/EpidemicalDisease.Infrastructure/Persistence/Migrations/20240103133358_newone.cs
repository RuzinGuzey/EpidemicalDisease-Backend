using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpidemicalDisease.Infrastructure.Persistence.Migrations
{
    public partial class newone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccineTypes_MedicalCenters_MedicalCenterId",
                table: "VaccineTypes");

            migrationBuilder.DropIndex(
                name: "IX_VaccineTypes_MedicalCenterId",
                table: "VaccineTypes");

            migrationBuilder.DropColumn(
                name: "MedicalCenterId",
                table: "VaccineTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalCenterId",
                table: "VaccineTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VaccineTypes_MedicalCenterId",
                table: "VaccineTypes",
                column: "MedicalCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccineTypes_MedicalCenters_MedicalCenterId",
                table: "VaccineTypes",
                column: "MedicalCenterId",
                principalTable: "MedicalCenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
