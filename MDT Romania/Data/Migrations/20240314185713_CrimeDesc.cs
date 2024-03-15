using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT_Romania.Data.Migrations
{
    /// <inheritdoc />
    public partial class CrimeDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "Description",
               table: "Crimes",
               type: "nvarchar(max)",
               nullable: true,
               defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "Description",
               table: "Crimes");
        }
    }
}
