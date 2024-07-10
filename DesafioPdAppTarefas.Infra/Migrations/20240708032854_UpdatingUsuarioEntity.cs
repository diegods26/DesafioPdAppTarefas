using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPdAppTarefas.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingUsuarioEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SENHA",
                table: "TB_USURIO");

            migrationBuilder.AddColumn<byte[]>(
                name: "PASSWORD_HASH",
                table: "TB_USURIO",
                type: "varbinary(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PASSWORD_SALT",
                table: "TB_USURIO",
                type: "varbinary(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_ATUALIZACAO",
                table: "TB_TAREFA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_CRIACAO",
                table: "TB_TAREFA",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USURIO_NOME",
                table: "TB_USURIO",
                column: "NOME",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_USURIO_NOME",
                table: "TB_USURIO");

            migrationBuilder.DropColumn(
                name: "PASSWORD_HASH",
                table: "TB_USURIO");

            migrationBuilder.DropColumn(
                name: "PASSWORD_SALT",
                table: "TB_USURIO");

            migrationBuilder.DropColumn(
                name: "DATA_ATUALIZACAO",
                table: "TB_TAREFA");

            migrationBuilder.DropColumn(
                name: "DATA_CRIACAO",
                table: "TB_TAREFA");

            migrationBuilder.AddColumn<string>(
                name: "SENHA",
                table: "TB_USURIO",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
