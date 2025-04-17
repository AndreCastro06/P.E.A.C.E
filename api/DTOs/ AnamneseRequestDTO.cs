using System.ComponentModel.DataAnnotations;
using PEACE.api.Enums;
using PeaceApi.Enums;

namespace PEACE.api.DTOs
{
    public class AnamneseRequestDTO
    {
        // Identificação
        [Required]
        public int PacienteId { get; set; }

        [Required]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; }

        // Dados clínicos
        public bool HistoricoPessoal_HAS { get; set; }
        public bool HistoricoPessoal_DM { get; set; }
        public bool HistoricoPessoal_Hipercolesterolemia { get; set; }
        public bool HistoricoPessoal_DoencaCardiaca { get; set; }

        // Histórico familiar
        public bool HistoricoFamiliar_HAS { get; set; }
        public bool HistoricoFamiliar_DM { get; set; }
        public bool HistoricoFamiliar_Hipercolesterolemia { get; set; }
        public bool HistoricoFamiliar_DoencaCardiaca { get; set; }

        // Medicações e suplementos
        public bool UsaMedicamento { get; set; }
        public string? Medicamentos { get; set; }

        public bool UsaSuplemento { get; set; }
        public string? Suplementos { get; set; }

        // Alergias e restrições
        public bool TemAlergiaAlimentar { get; set; }
        public string? Alergias { get; set; }

        public bool IntoleranciaLactose { get; set; }
        public string? Intolerancias { get; set; }

        public string? AversoesAlimentares { get; set; }

        // Atividade física
        public bool PraticaAtividadeFisica { get; set; }
        public string? AtividadeFisicaTipo { get; set; }
        public string? AtividadeFisicaHorario { get; set; }
        public string? AtividadeFisicaFrequencia { get; set; }

        // Dados corporais e rotina
        [Required]
        public Sexo Sexo { get; set; }

        [Required]
        [Range(10, 400)]
        public double Peso { get; set; }

        [Required]
        [Range(50, 250)]
        public double Altura { get; set; }

        public FatorAtividade FatorAtividade { get; set; } = FatorAtividade.Sedentario;

        public double? ConsumoAguaDiario { get; set; } // litros

        public FrequenciaIntestinal FrequenciaIntestinal { get; set; } = FrequenciaIntestinal.Desconhecida;

        public string? Ocupacao { get; set; }
    }
}