using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PeaceApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePregasCutaneas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Nutricionistas_NutricionistaId",
                table: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Alimentos",
                newName: "Descricao");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TabelaTaco",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Anotacao",
                table: "Refeicoes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnotacaoEditadaEm",
                table: "Refeicoes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quantidade",
                table: "ItensConsumidos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Carboidrato",
                table: "Alimentos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Energia",
                table: "Alimentos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lipidio",
                table: "Alimentos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Proteina",
                table: "Alimentos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    NomeCompleto = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ocupacao = table.Column<string>(type: "text", nullable: true),
                    PraticaAtividadeFisica = table.Column<bool>(type: "boolean", nullable: false),
                    AtividadeFisicaTipo = table.Column<string>(type: "text", nullable: true),
                    AtividadeFisicaHorario = table.Column<string>(type: "text", nullable: true),
                    AtividadeFisicaFrequencia = table.Column<string>(type: "text", nullable: true),
                    HistoricoFamiliar_HAS = table.Column<bool>(type: "boolean", nullable: false),
                    HistoricoFamiliar_DM = table.Column<bool>(type: "boolean", nullable: false),
                    HistoricoFamiliar_Hipercolesterolemia = table.Column<bool>(type: "boolean", nullable: false),
                    HistoricoFamiliar_DoencaCardiaca = table.Column<bool>(type: "boolean", nullable: false),
                    HistoricoPessoal_HAS = table.Column<bool>(type: "boolean", nullable: false),
                    HistoricoPessoal_DM = table.Column<bool>(type: "boolean", nullable: false),
                    HistoricoPessoal_Hipercolesterolemia = table.Column<bool>(type: "boolean", nullable: false),
                    HistoricoPessoal_DoencaCardiaca = table.Column<bool>(type: "boolean", nullable: false),
                    UsaMedicamento = table.Column<bool>(type: "boolean", nullable: false),
                    Medicamentos = table.Column<string>(type: "text", nullable: true),
                    UsaSuplemento = table.Column<bool>(type: "boolean", nullable: false),
                    Suplementos = table.Column<string>(type: "text", nullable: true),
                    TemAlergiaAlimentar = table.Column<bool>(type: "boolean", nullable: false),
                    Alergias = table.Column<string>(type: "text", nullable: true),
                    IntoleranciaLactose = table.Column<bool>(type: "boolean", nullable: false),
                    AversoesAlimentares = table.Column<string>(type: "text", nullable: true),
                    ConsumoAguaDiario = table.Column<string>(type: "text", nullable: true),
                    FrequenciaIntestinal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anamneses_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnotacoesRefeicaoHistorico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RefeicaoId = table.Column<int>(type: "integer", nullable: false),
                    TextoAnterior = table.Column<string>(type: "text", nullable: false),
                    EditadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotacoesRefeicaoHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnotacoesRefeicaoHistorico_Refeicoes_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacoesAntropometricas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    Sexo = table.Column<string>(type: "text", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    Peso = table.Column<double>(type: "double precision", nullable: false),
                    PesoEmLibras = table.Column<bool>(type: "boolean", nullable: false),
                    Altura = table.Column<double>(type: "double precision", nullable: false),
                    CircunferenciaCintura = table.Column<double>(type: "double precision", nullable: false),
                    CircunferenciaQuadril = table.Column<double>(type: "double precision", nullable: false),
                    GEB = table.Column<double>(type: "double precision", nullable: false),
                    GET = table.Column<double>(type: "double precision", nullable: false),
                    FatorAtividade = table.Column<int>(type: "integer", nullable: false),
                    Metodo = table.Column<int>(type: "integer", nullable: false),
                    PercentualGordura = table.Column<double>(type: "double precision", nullable: false),
                    MassaGorda = table.Column<double>(type: "double precision", nullable: false),
                    MassaMagra = table.Column<double>(type: "double precision", nullable: false),
                    TMB = table.Column<double>(type: "double precision", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacoesAntropometricas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacoesAntropometricas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastoEnergeticoHistorico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    Protocolo = table.Column<int>(type: "integer", nullable: false),
                    Sexo = table.Column<int>(type: "integer", nullable: false),
                    FatorAtividade = table.Column<int>(type: "integer", nullable: false),
                    Peso = table.Column<double>(type: "double precision", nullable: false),
                    Altura = table.Column<double>(type: "double precision", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false),
                    GEB = table.Column<double>(type: "double precision", nullable: false),
                    GET = table.Column<double>(type: "double precision", nullable: false),
                    DataCalculo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastoEnergeticoHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GastoEnergeticoHistorico_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PregasCutaneas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AvaliacaoAntropometricaId = table.Column<int>(type: "integer", nullable: false),
                    PCB = table.Column<double>(type: "double precision", nullable: true),
                    PCT = table.Column<double>(type: "double precision", nullable: true),
                    PCSA = table.Column<double>(type: "double precision", nullable: true),
                    PCSE = table.Column<double>(type: "double precision", nullable: true),
                    PCSI = table.Column<double>(type: "double precision", nullable: true),
                    PCAB = table.Column<double>(type: "double precision", nullable: true),
                    PCP = table.Column<double>(type: "double precision", nullable: true),
                    PCCX = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregasCutaneas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PregasCutaneas_AvaliacoesAntropometricas_AvaliacaoAntropome~",
                        column: x => x.AvaliacaoAntropometricaId,
                        principalTable: "AvaliacoesAntropometricas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anamneses_PacienteId",
                table: "Anamneses",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AnotacoesRefeicaoHistorico_RefeicaoId",
                table: "AnotacoesRefeicaoHistorico",
                column: "RefeicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacoesAntropometricas_PacienteId",
                table: "AvaliacoesAntropometricas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_GastoEnergeticoHistorico_PacienteId",
                table: "GastoEnergeticoHistorico",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PregasCutaneas_AvaliacaoAntropometricaId",
                table: "PregasCutaneas",
                column: "AvaliacaoAntropometricaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Nutricionistas_NutricionistaId",
                table: "Pacientes",
                column: "NutricionistaId",
                principalTable: "Nutricionistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Nutricionistas_NutricionistaId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "Anamneses");

            migrationBuilder.DropTable(
                name: "AnotacoesRefeicaoHistorico");

            migrationBuilder.DropTable(
                name: "GastoEnergeticoHistorico");

            migrationBuilder.DropTable(
                name: "PregasCutaneas");

            migrationBuilder.DropTable(
                name: "AvaliacoesAntropometricas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TabelaTaco");

            migrationBuilder.DropColumn(
                name: "Anotacao",
                table: "Refeicoes");

            migrationBuilder.DropColumn(
                name: "AnotacaoEditadaEm",
                table: "Refeicoes");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItensConsumidos");

            migrationBuilder.DropColumn(
                name: "Carboidrato",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "Energia",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "Lipidio",
                table: "Alimentos");

            migrationBuilder.DropColumn(
                name: "Proteina",
                table: "Alimentos");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Alimentos",
                newName: "Nome");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Nutricionistas_NutricionistaId",
                table: "Pacientes",
                column: "NutricionistaId",
                principalTable: "Nutricionistas",
                principalColumn: "Id");
        }
    }
}
