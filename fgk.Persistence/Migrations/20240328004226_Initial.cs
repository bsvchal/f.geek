using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace fgk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Word = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Runtime = table.Column<int>(type: "integer", nullable: false),
                    ShortDescription = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Tagline = table.Column<string>(type: "text", nullable: true),
                    Budget = table.Column<long>(type: "bigint", nullable: false),
                    Revenue = table.Column<long>(type: "bigint", nullable: false),
                    Rated = table.Column<string>(type: "text", nullable: false),
                    PosterURL = table.Column<string>(type: "text", nullable: true),
                    LikesAmount = table.Column<int>(type: "integer", nullable: false),
                    IMDbRating = table.Column<int>(type: "integer", nullable: true),
                    RottenTomatoesRating = table.Column<int>(type: "integer", nullable: true),
                    MetacriticRating = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Character = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    FromMovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cast_Movies_FromMovieId",
                        column: x => x.FromMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    Job = table.Column<string>(type: "text", nullable: false),
                    FromMovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_Movies_FromMovieId",
                        column: x => x.FromMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreEntityMovieEntity",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "integer", nullable: false),
                    MoviesOfThisGenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreEntityMovieEntity", x => new { x.GenresId, x.MoviesOfThisGenreId });
                    table.ForeignKey(
                        name: "FK_GenreEntityMovieEntity_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreEntityMovieEntity_Movies_MoviesOfThisGenreId",
                        column: x => x.MoviesOfThisGenreId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeywordEntityMovieEntity",
                columns: table => new
                {
                    KeywordsId = table.Column<int>(type: "integer", nullable: false),
                    MoviesWithThisKeywordId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordEntityMovieEntity", x => new { x.KeywordsId, x.MoviesWithThisKeywordId });
                    table.ForeignKey(
                        name: "FK_KeywordEntityMovieEntity_Keywords_KeywordsId",
                        column: x => x.KeywordsId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordEntityMovieEntity_Movies_MoviesWithThisKeywordId",
                        column: x => x.MoviesWithThisKeywordId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    YouTubeURL = table.Column<string>(type: "text", nullable: false),
                    FromMovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Movies_FromMovieId",
                        column: x => x.FromMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieEntityProductionCountryEntity",
                columns: table => new
                {
                    MoviesFromThisCountryId = table.Column<int>(type: "integer", nullable: false),
                    ProductionCountriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEntityProductionCountryEntity", x => new { x.MoviesFromThisCountryId, x.ProductionCountriesId });
                    table.ForeignKey(
                        name: "FK_MovieEntityProductionCountryEntity_Movies_MoviesFromThisCou~",
                        column: x => x.MoviesFromThisCountryId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEntityProductionCountryEntity_ProductionCountries_Prod~",
                        column: x => x.ProductionCountriesId,
                        principalTable: "ProductionCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cast_FromMovieId",
                table: "Cast",
                column: "FromMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_FromMovieId",
                table: "Crew",
                column: "FromMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreEntityMovieEntity_MoviesOfThisGenreId",
                table: "GenreEntityMovieEntity",
                column: "MoviesOfThisGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordEntityMovieEntity_MoviesWithThisKeywordId",
                table: "KeywordEntityMovieEntity",
                column: "MoviesWithThisKeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieEntityProductionCountryEntity_ProductionCountriesId",
                table: "MovieEntityProductionCountryEntity",
                column: "ProductionCountriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_FromMovieId",
                table: "Videos",
                column: "FromMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "GenreEntityMovieEntity");

            migrationBuilder.DropTable(
                name: "KeywordEntityMovieEntity");

            migrationBuilder.DropTable(
                name: "MovieEntityProductionCountryEntity");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "ProductionCountries");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
