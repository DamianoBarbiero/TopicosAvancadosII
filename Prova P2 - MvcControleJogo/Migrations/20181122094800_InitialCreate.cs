using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcControleJogo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCategoria = table.Column<string>(nullable: true),
                    DescricaoCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCliente = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    AnoNasc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    Fundacao = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plataforma",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomePlataforma = table.Column<string>(nullable: true),
                    DescricaoPlataforma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataforma", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeJogo = table.Column<string>(nullable: true),
                    NomeCategoriaFKID = table.Column<int>(nullable: true),
                    NomePlataformaFKID = table.Column<int>(nullable: true),
                    DesenvolvedorFKID = table.Column<int>(nullable: true),
                    AnoLanc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jogos_Empresa_DesenvolvedorFKID",
                        column: x => x.DesenvolvedorFKID,
                        principalTable: "Empresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jogos_Categoria_NomeCategoriaFKID",
                        column: x => x.NomeCategoriaFKID,
                        principalTable: "Categoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jogos_Plataforma_NomePlataformaFKID",
                        column: x => x.NomePlataformaFKID,
                        principalTable: "Plataforma",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteJogo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeClienteFKID = table.Column<int>(nullable: true),
                    NomeJogoFKID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteJogo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClienteJogo_Cliente_NomeClienteFKID",
                        column: x => x.NomeClienteFKID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteJogo_Jogos_NomeJogoFKID",
                        column: x => x.NomeJogoFKID,
                        principalTable: "Jogos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteJogo_NomeClienteFKID",
                table: "ClienteJogo",
                column: "NomeClienteFKID");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteJogo_NomeJogoFKID",
                table: "ClienteJogo",
                column: "NomeJogoFKID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_DesenvolvedorFKID",
                table: "Jogos",
                column: "DesenvolvedorFKID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_NomeCategoriaFKID",
                table: "Jogos",
                column: "NomeCategoriaFKID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_NomePlataformaFKID",
                table: "Jogos",
                column: "NomePlataformaFKID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteJogo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Plataforma");
        }
    }
}
