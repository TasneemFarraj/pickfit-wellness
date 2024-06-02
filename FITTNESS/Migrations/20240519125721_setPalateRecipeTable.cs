using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITTNESS.Migrations
{
    /// <inheritdoc />
    public partial class setPalateRecipeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalateRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreparationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalateRecipe", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalateRecipe");
        }
    }
}
