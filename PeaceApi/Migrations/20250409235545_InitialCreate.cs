using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PeaceApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Fonte = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeReferencia = table.Column<double>(type: "double precision", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlimentosUSDA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DescricaoIngles = table.Column<string>(type: "text", nullable: false),
                    DescricaoTraduzida = table.Column<string>(type: "text", nullable: true),
                    QuantidadePadrao = table.Column<double>(type: "double precision", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentosUSDA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FailedCount = table.Column<int>(type: "integer", nullable: false),
                    LastAttempt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaTaco",
                columns: table => new
                {
                    NumeroAlimento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Umidade = table.Column<double>(type: "double precision", nullable: true),
                    EnergiaKcal = table.Column<double>(type: "double precision", nullable: true),
                    EnergiaKj = table.Column<double>(type: "double precision", nullable: true),
                    Proteina = table.Column<double>(type: "double precision", nullable: true),
                    Lipideos = table.Column<double>(type: "double precision", nullable: true),
                    Colesterol = table.Column<double>(type: "double precision", nullable: true),
                    Carboidrato = table.Column<double>(type: "double precision", nullable: true),
                    FibraAlimentar = table.Column<double>(type: "double precision", nullable: true),
                    Cinzas = table.Column<double>(type: "double precision", nullable: true),
                    Calcio = table.Column<double>(type: "double precision", nullable: true),
                    Magnesio = table.Column<double>(type: "double precision", nullable: true),
                    Manganes = table.Column<double>(type: "double precision", nullable: true),
                    Fosforo = table.Column<double>(type: "double precision", nullable: true),
                    Ferro = table.Column<double>(type: "double precision", nullable: true),
                    Sodio = table.Column<double>(type: "double precision", nullable: true),
                    Potassio = table.Column<double>(type: "double precision", nullable: true),
                    Cobre = table.Column<double>(type: "double precision", nullable: true),
                    Zinco = table.Column<double>(type: "double precision", nullable: true),
                    Retinol = table.Column<double>(type: "double precision", nullable: true),
                    RE = table.Column<double>(type: "double precision", nullable: true),
                    RAE = table.Column<double>(type: "double precision", nullable: true),
                    Tiamina = table.Column<double>(type: "double precision", nullable: true),
                    Riboflavina = table.Column<double>(type: "double precision", nullable: true),
                    Piridoxina = table.Column<double>(type: "double precision", nullable: true),
                    Niacina = table.Column<double>(type: "double precision", nullable: true),
                    VitaminaC = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaTaco", x => x.NumeroAlimento);
                });

            migrationBuilder.CreateTable(
                name: "Nutriente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Unidade = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Subtipo = table.Column<int>(type: "integer", nullable: false),
                    AlimentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutriente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nutriente_Alimentos_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutrientesUSDA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeOriginal = table.Column<string>(type: "text", nullable: false),
                    NomePadronizado = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    Unidade = table.Column<string>(type: "text", nullable: false),
                    Subtipo = table.Column<int>(type: "integer", nullable: false),
                    AlimentoUSDAId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientesUSDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutrientesUSDA_AlimentosUSDA_AlimentoUSDAId",
                        column: x => x.AlimentoUSDAId,
                        principalTable: "AlimentosUSDA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    NutricionistaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Nutricionistas_NutricionistaId",
                        column: x => x.NutricionistaId,
                        principalTable: "Nutricionistas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcidosGraxosTaco",
                columns: table => new
                {
                    NumeroAlimento = table.Column<int>(type: "integer", nullable: false),
                    Saturados = table.Column<double>(type: "double precision", nullable: true),
                    Monoinsaturados = table.Column<double>(type: "double precision", nullable: true),
                    Poliinsaturados = table.Column<double>(type: "double precision", nullable: true),
                    DozeZero = table.Column<double>(type: "double precision", nullable: true),
                    QuatorzeZero = table.Column<double>(type: "double precision", nullable: true),
                    DezesseisZero = table.Column<double>(type: "double precision", nullable: true),
                    DezoitoZero = table.Column<double>(type: "double precision", nullable: true),
                    VinteZero = table.Column<double>(type: "double precision", nullable: true),
                    VinteDoisZero = table.Column<double>(type: "double precision", nullable: true),
                    VinteQuatroZero = table.Column<double>(type: "double precision", nullable: true),
                    QuatorzeUm = table.Column<double>(type: "double precision", nullable: true),
                    DezesseisUm = table.Column<double>(type: "double precision", nullable: true),
                    DezoitoUm = table.Column<double>(type: "double precision", nullable: true),
                    VinteUm = table.Column<double>(type: "double precision", nullable: true),
                    DezoitoDoisN6 = table.Column<double>(type: "double precision", nullable: true),
                    DezoitoTresN3 = table.Column<double>(type: "double precision", nullable: true),
                    VinteQuatroCinco = table.Column<double>(type: "double precision", nullable: true),
                    VinteCincoCinco = table.Column<double>(type: "double precision", nullable: true),
                    VinteDoisCinco = table.Column<double>(type: "double precision", nullable: true),
                    VinteDoisSeis = table.Column<double>(type: "double precision", nullable: true),
                    DezoitoUmT = table.Column<double>(type: "double precision", nullable: true),
                    DezoitoDoisT = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcidosGraxosTaco", x => x.NumeroAlimento);
                    table.ForeignKey(
                        name: "FK_AcidosGraxosTaco_TabelaTaco_NumeroAlimento",
                        column: x => x.NumeroAlimento,
                        principalTable: "TabelaTaco",
                        principalColumn: "NumeroAlimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AminoacidosTaco",
                columns: table => new
                {
                    NumeroAlimento = table.Column<int>(type: "integer", nullable: false),
                    Triptofano = table.Column<double>(type: "double precision", nullable: true),
                    Treonina = table.Column<double>(type: "double precision", nullable: true),
                    Isoleucina = table.Column<double>(type: "double precision", nullable: true),
                    Leucina = table.Column<double>(type: "double precision", nullable: true),
                    Lisina = table.Column<double>(type: "double precision", nullable: true),
                    Metionina = table.Column<double>(type: "double precision", nullable: true),
                    Cistina = table.Column<double>(type: "double precision", nullable: true),
                    Fenilalanina = table.Column<double>(type: "double precision", nullable: true),
                    Tirosina = table.Column<double>(type: "double precision", nullable: true),
                    Valina = table.Column<double>(type: "double precision", nullable: true),
                    Arginina = table.Column<double>(type: "double precision", nullable: true),
                    Histidina = table.Column<double>(type: "double precision", nullable: true),
                    Alanina = table.Column<double>(type: "double precision", nullable: true),
                    Aspartico = table.Column<double>(type: "double precision", nullable: true),
                    Glutamico = table.Column<double>(type: "double precision", nullable: true),
                    Glicina = table.Column<double>(type: "double precision", nullable: true),
                    Prolina = table.Column<double>(type: "double precision", nullable: true),
                    Serina = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AminoacidosTaco", x => x.NumeroAlimento);
                    table.ForeignKey(
                        name: "FK_AminoacidosTaco_TabelaTaco_NumeroAlimento",
                        column: x => x.NumeroAlimento,
                        principalTable: "TabelaTaco",
                        principalColumn: "NumeroAlimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refeicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PacienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refeicoes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensConsumidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuantidadeGramas = table.Column<double>(type: "double precision", nullable: false),
                    RefeicaoId = table.Column<int>(type: "integer", nullable: false),
                    AlimentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensConsumidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensConsumidos_Alimentos_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensConsumidos_Refeicoes_RefeicaoId",
                        column: x => x.RefeicaoId,
                        principalTable: "Refeicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensConsumidos_AlimentoId",
                table: "ItensConsumidos",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensConsumidos_RefeicaoId",
                table: "ItensConsumidos",
                column: "RefeicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutriente_AlimentoId",
                table: "Nutriente",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrientesUSDA_AlimentoUSDAId",
                table: "NutrientesUSDA",
                column: "AlimentoUSDAId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_NutricionistaId",
                table: "Pacientes",
                column: "NutricionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Refeicoes_PacienteId",
                table: "Refeicoes",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcidosGraxosTaco");

            migrationBuilder.DropTable(
                name: "AminoacidosTaco");

            migrationBuilder.DropTable(
                name: "ItensConsumidos");

            migrationBuilder.DropTable(
                name: "LoginAttempts");

            migrationBuilder.DropTable(
                name: "Nutriente");

            migrationBuilder.DropTable(
                name: "NutrientesUSDA");

            migrationBuilder.DropTable(
                name: "TabelaTaco");

            migrationBuilder.DropTable(
                name: "Refeicoes");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "AlimentosUSDA");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Nutricionistas");
        }
    }
}
