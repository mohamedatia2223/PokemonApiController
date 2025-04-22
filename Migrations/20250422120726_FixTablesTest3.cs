using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class FixTablesTest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Pokemons_PokemonId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "OwnersId",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Reviews",
                newName: "reviewerId");

            migrationBuilder.RenameColumn(
                name: "PokemonId",
                table: "Reviews",
                newName: "pokemonId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                newName: "IX_Reviews_reviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PokemonId",
                table: "Reviews",
                newName: "IX_Reviews_pokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Pokemons_pokemonId",
                table: "Reviews",
                column: "pokemonId",
                principalTable: "Pokemons",
                principalColumn: "PokemonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_reviewerId",
                table: "Reviews",
                column: "reviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Pokemons_pokemonId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_reviewerId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "reviewerId",
                table: "Reviews",
                newName: "ReviewerId");

            migrationBuilder.RenameColumn(
                name: "pokemonId",
                table: "Reviews",
                newName: "PokemonId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_reviewerId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_pokemonId",
                table: "Reviews",
                newName: "IX_Reviews_PokemonId");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnersId",
                table: "Pokemons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Pokemons_PokemonId",
                table: "Reviews",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "PokemonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
