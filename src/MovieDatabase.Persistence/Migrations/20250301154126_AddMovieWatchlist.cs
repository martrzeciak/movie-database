using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieWatchlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    MovieWatchlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersWantToWatchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.MovieWatchlistId, x.UsersWantToWatchId });
                    table.ForeignKey(
                        name: "FK_MovieUser_AspNetUsers_UsersWantToWatchId",
                        column: x => x.UsersWantToWatchId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_Movies_MovieWatchlistId",
                        column: x => x.MovieWatchlistId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_UsersWantToWatchId",
                table: "MovieUser",
                column: "UsersWantToWatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieUser");
        }
    }
}
