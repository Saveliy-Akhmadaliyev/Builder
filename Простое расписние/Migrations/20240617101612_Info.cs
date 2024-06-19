using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Простое_расписние.Migrations
{
    /// <inheritdoc />
    public partial class Info : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Lesson",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Lesson");
        }
    }
}
