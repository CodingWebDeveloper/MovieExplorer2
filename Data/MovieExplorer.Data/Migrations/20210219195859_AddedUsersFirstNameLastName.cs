using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieExplorer.Data.Migrations
{
    public partial class AddedUsersFirstNameLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 19, 19, 58, 58, 610, DateTimeKind.Utc).AddTicks(841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 19, 12, 2, 3, 56, DateTimeKind.Utc).AddTicks(8985));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 19, 12, 2, 3, 56, DateTimeKind.Utc).AddTicks(8985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 19, 19, 58, 58, 610, DateTimeKind.Utc).AddTicks(841));
        }
    }
}
