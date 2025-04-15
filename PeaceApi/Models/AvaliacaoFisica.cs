using System.ComponentModel.DataAnnotations;
using PEACE.api.Enums;

namespace PEACE.api.Models
{
    public class AvaliacaoFisica
    {
        public int Id { get; set; }

        [Required]
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        public DateTime DataAvaliacao { get; set; } = DateTime.UtcNow;
        public PregasCutaneas? PregasCutaneas { get; set; }

        // Circunferências
        public double? CBD { get; set; }  // Braço direito
        public double? CBE { get; set; }  // Braço esquerdo
        public double? CCXE { get; set; } // Coxa esquerda
        public double? CCXD { get; set; } // Coxa direita
        public double? CQ { get; set; }   // Quadril
        public double? CP { get; set; }   // Peitoral
        public double? CCYU { get; set; } // Cintura umbilical
        public double? CT { get; set; }   // Torácica
        public double GEB { get; set; }
        public double GET { get; set; }

        public FatorAtividade FatorAtividade { get; set; }

        public DateTime DataAvaliacao { get; set; } = DateTime.UtcNow;


    }
}