using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieExplorer.Data.Migrations
{
    public partial class ChangedMovieActorAndMovieGenere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 4, 16, 46, 47, 931, DateTimeKind.Utc).AddTicks(8386),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 1, 16, 59, 1, 801, DateTimeKind.Utc).AddTicks(2121));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MoviesActors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "MoviesActors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MoviesActors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MoviesActors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "MoviesActors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MovieGenres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "MovieGenres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MovieGenres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MovieGenres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "MovieGenres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActors_IsDeleted",
                table: "MoviesActors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_IsDeleted",
                table: "MovieGenres",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MoviesActors_IsDeleted",
                table: "MoviesActors");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_IsDeleted",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MoviesActors");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "MoviesActors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MoviesActors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MoviesActors");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "MoviesActors");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "MovieGenres");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "MoviesUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 1, 16, 59, 1, 801, DateTimeKind.Utc).AddTicks(2121),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 4, 16, 46, 47, 931, DateTimeKind.Utc).AddTicks(8386));
        }
    }
}
