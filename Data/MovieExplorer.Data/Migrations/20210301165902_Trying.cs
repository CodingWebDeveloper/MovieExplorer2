using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieExplorer.Data.Migrations
{
    public partial class Trying : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 1, 16, 59, 1, 801, DateTimeKind.Utc).AddTicks(2121),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 26, 14, 26, 39, 702, DateTimeKind.Utc).AddTicks(4799));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MoviesUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MoviesUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesUsers_IsDeleted",
                table: "MoviesUsers",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MoviesUsers_IsDeleted",
                table: "MoviesUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MoviesUsers");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "MoviesUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MoviesUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MoviesUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "MoviesUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 26, 14, 26, 39, 702, DateTimeKind.Utc).AddTicks(4799),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 1, 16, 59, 1, 801, DateTimeKind.Utc).AddTicks(2121));
        }
    }
}
