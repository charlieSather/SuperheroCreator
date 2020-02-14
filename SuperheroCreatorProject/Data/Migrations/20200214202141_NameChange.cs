using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperheroCreatorProject.Data.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes");

            migrationBuilder.RenameTable(
                name: "SuperHeroes",
                newName: "Superheroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Superheroes",
                table: "Superheroes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Superheroes",
                table: "Superheroes");

            migrationBuilder.RenameTable(
                name: "Superheroes",
                newName: "SuperHeroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes",
                column: "Id");
        }
    }
}
