using Microsoft.EntityFrameworkCore.Migrations;

namespace OzonePrime.Migrations
{
    public partial class fixmapingtablePKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "user_id",
                table: "users_roles",
                newName: "user_id1");

            migrationBuilder.RenameIndex(
                name: "film_id",
                table: "films_users",
                newName: "film_id2");

            migrationBuilder.RenameIndex(
                name: "film_id",
                table: "films_genres",
                newName: "film_id1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users_roles",
                table: "users_roles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_films_users",
                table: "films_users",
                columns: new[] { "film_id", "user_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_films_genres",
                table: "films_genres",
                columns: new[] { "film_id", "genre_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_films_cast",
                table: "films_cast",
                columns: new[] { "film_id", "cast_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users_roles",
                table: "users_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_films_users",
                table: "films_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_films_genres",
                table: "films_genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_films_cast",
                table: "films_cast");

            migrationBuilder.RenameIndex(
                name: "user_id1",
                table: "users_roles",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "film_id2",
                table: "films_users",
                newName: "film_id");

            migrationBuilder.RenameIndex(
                name: "film_id1",
                table: "films_genres",
                newName: "film_id");
        }
    }
}
