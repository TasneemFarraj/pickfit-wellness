using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITTNESS.Migrations
{
    /// <inheritdoc />
    public partial class setPalateIngredientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalateIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_7 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalateIngredient", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalateIngredient");
        }
    }
}
