using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PEACE.api.Models
{
    public class Anamnese
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente? Paciente { get; set; }

        [Required]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public int Idade => DateTime.Today.Year - DataNascimento.Year -
            (DateTime.Today.DayOfYear < DataNascimento.DayOfYear ? 1 : 0);

        public string? Ocupacao { get; set; }

        public bool PraticaAtividadeFisica { get; set; }
        public string? AtividadeFisicaTipo { get; set; }
        public string? AtividadeFisicaHorario { get; set; }
        public string? AtividadeFisicaFrequencia { get; set; }

        public bool HistoricoFamiliar_HAS { get; set; }
        public bool HistoricoFamiliar_DM { get; set; }
        public bool HistoricoFamiliar_Hipercolesterolemia { get; set; }
        public bool HistoricoFamiliar_DoencaCardiaca { get; set; }

        public bool HistoricoPessoal_HAS { get; set; }
        public bool HistoricoPessoal_DM { get; set; }
        public bool HistoricoPessoal_Hipercolesterolemia { get; set; }
        public bool HistoricoPessoal_DoencaCardiaca { get; set; }

        public bool UsaMedicamento { get; set; }
        public string? Medicamentos { get; set; }

        public bool UsaSuplemento { get; set; }
        public string? Suplementos { get; set; }

        public bool TemAlergiaAlimentar { get; set; }
        public string? Alergias { get; set; }

        public bool IntoleranciaLactose { get; set; }

        public string? AversoesAlimentares { get; set; }

        public string? ConsumoAguaDiario { get; set; }

        public FrequenciaIntestinal FrequenciaIntestinal { get; set; } = FrequenciaIntestinal.Desconhecida;
    }

    public enum FrequenciaIntestinal
    {
        Desconhecida = 0,
        Diaria = 1,
        ACada2a3Dias = 2,
        MaisDe4Dias = 3
    }
}