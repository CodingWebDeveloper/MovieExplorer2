using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieExplorer.Data.Migrations
{
    public partial class DeleteExtensionProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Images",
                newName: "ImageUrl");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MoviesActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoviesActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActors_ActorId",
                table: "MoviesActors",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesActors");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Images",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
