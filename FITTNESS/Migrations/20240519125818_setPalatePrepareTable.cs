using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FITTNESS.Migrations
{
    /// <inheritdoc />
    public partial class setPalatePrepareTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalatePrepare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    step_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    step_7 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalatePrepare", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalatePrepare");
        }
    }
}
