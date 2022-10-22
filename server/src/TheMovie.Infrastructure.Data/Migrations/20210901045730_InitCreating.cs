using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMovie.Infrastructure.Data.Migrations
{
    public partial class InitCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Sinopse = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Genero = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Favorito = table.Column<bool>(type: "bit", nullable: false),
                    CascadeMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
