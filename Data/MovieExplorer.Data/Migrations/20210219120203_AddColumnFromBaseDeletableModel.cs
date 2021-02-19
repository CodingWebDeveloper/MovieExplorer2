using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieExplorer.Data.Migrations
{
    public partial class AddColumnFromBaseDeletableModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 19, 12, 2, 3, 56, DateTimeKind.Utc).AddTicks(8985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 19, 11, 37, 31, 533, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Genres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Genres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Directors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Directors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Directors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Directors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Actors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Actors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Actors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Actors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_IsDeleted",
                table: "Movies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_IsDeleted",
                table: "Genres",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_IsDeleted",
                table: "Directors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_IsDeleted",
                table: "Countries",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_IsDeleted",
                table: "Actors",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movies_IsDeleted",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Genres_IsDeleted",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Directors_IsDeleted",
                table: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Countries_IsDeleted",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Actors_IsDeleted",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Actors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 2, 19, 11, 37, 31, 533, DateTimeKind.Utc).AddTicks(6056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 2, 19, 12, 2, 3, 56, DateTimeKind.Utc).AddTicks(8985));
        }
    }
}
