using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT_Romania.Data.Migrations
{
    /// <inheritdoc />
    public partial class CitizenId_Gender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CitizenId",
                table: "Civilians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Civilians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitizenId",
                table: "Civilians");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Civilians");
        }
    }
}
