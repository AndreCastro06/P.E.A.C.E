using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PeaceApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSuplemento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanosAlimentares_Pacientes_PacienteId",
                table: "PlanosAlimentares");

            migrationBuilder.DropForeignKey(
                name: "FK_RefeicoesPlano_PlanosAlimentares_PlanoAlimentarId",
                table: "RefeicoesPlano");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanosAlimentares",
                table: "PlanosAlimentares");

            migrationBuilder.RenameTable(
                name: "PlanosAlimentares",
                newName: "PlanoAlimentar");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pacientes",
                newName: "NomeCompleto");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Nutricionistas",
                newName: "NomeCompleto");

            migrationBuilder.RenameIndex(
                name: "IX_PlanosAlimentares_PacienteId",
                table: "PlanoAlimentar",
                newName: "IX_PlanoAlimentar_PacienteId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Pacientes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanoAlimentar",
                table: "PlanoAlimentar",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Suplementos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Posologia = table.Column<string>(type: "text", nullable: false),
                    Horario = table.Column<string>(type: "text", nullable: false),
                    Finalidade = table.Column<string>(type: "text", nullable: false),
                    PacienteId = table.Column<int>(type: "integer", nullable: true),
                    PlanoAlimentarId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplementos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suplementos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Suplementos_PlanoAlimentar_PlanoAlimentarId",
                        column: x => x.PlanoAlimentarId,
                        principalTable: "PlanoAlimentar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suplementos_PacienteId",
                table: "Suplementos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Suplementos_PlanoAlimentarId",
                table: "Suplementos",
                column: "PlanoAlimentarId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanoAlimentar_Pacientes_PacienteId",
                table: "PlanoAlimentar",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefeicoesPlano_PlanoAlimentar_PlanoAlimentarId",
                table: "RefeicoesPlano",
                column: "PlanoAlimentarId",
                principalTable: "PlanoAlimentar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanoAlimentar_Pacientes_PacienteId",
                table: "PlanoAlimentar");

            migrationBuilder.DropForeignKey(
                name: "FK_RefeicoesPlano_PlanoAlimentar_PlanoAlimentarId",
                table: "RefeicoesPlano");

            migrationBuilder.DropTable(
                name: "Suplementos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanoAlimentar",
                table: "PlanoAlimentar");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Pacientes");

            migrationBuilder.RenameTable(
                name: "PlanoAlimentar",
                newName: "PlanosAlimentares");

            migrationBuilder.RenameColumn(
                name: "NomeCompleto",
                table: "Pacientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "NomeCompleto",
                table: "Nutricionistas",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_PlanoAlimentar_PacienteId",
                table: "PlanosAlimentares",
                newName: "IX_PlanosAlimentares_PacienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanosAlimentares",
                table: "PlanosAlimentares",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanosAlimentares_Pacientes_PacienteId",
                table: "PlanosAlimentares",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefeicoesPlano_PlanosAlimentares_PlanoAlimentarId",
                table: "RefeicoesPlano",
                column: "PlanoAlimentarId",
                principalTable: "PlanosAlimentares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
