using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class FixTablesTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Countries_CountryId",
                table: "Owners");

            migrationBuilder.DropTable(
                name: "CategoryPokemon");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Owners_CountryId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Owners");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Pokemons");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriesId",
                table: "Pokemons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Owners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CatName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PokemonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPokemon",
                columns: table => new
                {
                    CategoriesCatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PokemonsPokemonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPokemon", x => new { x.CategoriesCatId, x.PokemonsPokemonId });
                    table.ForeignKey(
                        name: "FK_CategoryPokemon_Categories_CategoriesCatId",
                        column: x => x.CategoriesCatId,
                        principalTable: "Categories",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPokemon_Pokemons_PokemonsPokemonId",
                        column: x => x.PokemonsPokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "PokemonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_CountryId",
                table: "Owners",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CatName",
                table: "Categories",
                column: "CatName");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPokemon_PokemonsPokemonId",
                table: "CategoryPokemon",
                column: "PokemonsPokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Countries_CountryId",
                table: "Owners",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");
        }
    }
}
