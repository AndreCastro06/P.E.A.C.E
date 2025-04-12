using PEACE.api.Models;

namespace PEACE.api.DTOs
{
    public class AvaliacaoAntropometricaDTO
    {
        public string Sexo { get; set; } = string.Empty;
        public int Idade { get; set; }
        public double Peso { get; set; }         // kg
        public bool PesoEmLibras { get; set; } = false;
        public double Altura { get; set; }       // cm

        // Dobras
        public double Tricipital { get; set; }
        public double Subescapular { get; set; }
        public double Suprailiaca { get; set; }
        public double Abdominal { get; set; }
        public double Coxa { get; set; }
        public double Peitoral { get; set; }
        public double Axilar { get; set; }
        public double Bicipital { get; set; }
        public double Panturrilha { get; set; }

        public MetodoAvaliacao ? Metodo { get; set; }
    }
}