using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPdAppTarefas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USURIO",
                columns: table => new
                {
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USURIO", x => x.USUARIO_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_TAREFA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITULO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS_TAREFA = table.Column<int>(type: "int", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TAREFA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TAREFA_TB_USURIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "TB_USURIO",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TAREFA_USUARIO_ID",
                table: "TB_TAREFA",
                column: "USUARIO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TAREFA");

            migrationBuilder.DropTable(
                name: "TB_USURIO");
        }
    }
}
