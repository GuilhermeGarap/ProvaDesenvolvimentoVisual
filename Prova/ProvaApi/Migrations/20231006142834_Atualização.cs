using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaApi.Migrations
{
    public partial class Atualização : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    FolhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    Quantidade = table.Column<float>(type: "REAL", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Salario_Bruto = table.Column<float>(type: "REAL", nullable: false),
                    Imposto_Renda = table.Column<float>(type: "REAL", nullable: false),
                    Inss = table.Column<float>(type: "REAL", nullable: false),
                    Fgts = table.Column<float>(type: "REAL", nullable: false),
                    Salario_Liquido = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.FolhaId);
                    table.ForeignKey(
                        name: "FK_Folhas_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_FuncionarioId",
                table: "Folhas",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
