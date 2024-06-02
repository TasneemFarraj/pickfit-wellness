using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITTNESS.Migrations
{
    /// <inheritdoc />
    public partial class InformationCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InformationCardId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InformationCardId",
                table: "Appointment");
        }
    }
}
