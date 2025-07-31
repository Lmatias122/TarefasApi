using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefasApi.Migrations
{
    /// <inheritdoc />
    public partial class LeftBasic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Tarefas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Prazo",
                table: "Tarefas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Prazo",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Tarefas");
        }
    }
}
