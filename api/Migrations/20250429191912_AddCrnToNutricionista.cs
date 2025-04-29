using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeaceApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCrnToNutricionista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CRN",
                table: "Nutricionistas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CRN",
                table: "Nutricionistas");
        }
    }
}
