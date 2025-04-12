using System.ComponentModel.DataAnnotations;
using PEACE.api.Models;

namespace PEACE.api.Models
{
    public class PregasCutaneas
    {
        public int Id { get; set; }

        [Required]
        public int AvaliacaoFisicaId { get; set; }
        public AvaliacaoFisica? AvaliacaoFisica { get; set; }

        // Pregas cutâneas (em mm)
        public double? PCB { get; set; }   // Peitoral
        public double? PCT { get; set; }   // Tricipital
        public double? PCSA { get; set; }  // Subescapular
        public double? PCSE { get; set; }  // Supraespinal
        public double? PCSI { get; set; }  // Suprailíaca
        public double? PCAB { get; set; }  // Abdominal
    }
}




