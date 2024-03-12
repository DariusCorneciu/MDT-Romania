﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT_Romania.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserfixv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOLOs_AspNetUsers_UserId",
                table: "BOLOs");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BOLOs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_BOLOs_AspNetUsers_UserId",
                table: "BOLOs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOLOs_AspNetUsers_UserId",
                table: "BOLOs");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BOLOs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BOLOs_AspNetUsers_UserId",
                table: "BOLOs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
