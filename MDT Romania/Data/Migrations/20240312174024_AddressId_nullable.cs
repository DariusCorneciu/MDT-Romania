using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT_Romania.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressId_nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Civilians_Addresses_AddressId",
                table: "Civilians");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Civilians",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Civilians_Addresses_AddressId",
                table: "Civilians",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Civilians_Addresses_AddressId",
                table: "Civilians");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Civilians",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Civilians_Addresses_AddressId",
                table: "Civilians",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
