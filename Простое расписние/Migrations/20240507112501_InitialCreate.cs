using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

namespace Простое_расписние.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lesson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mentor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AT", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AT");
        }
    }
}
