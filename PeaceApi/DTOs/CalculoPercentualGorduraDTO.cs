using PEACE.api.Models;

namespace PEACE.api.DTOs
{
    public class ComposicaoCorporalRequestDTO
    {
        public MetodoAvaliacao Metodo { get; set; }
        public string Sexo { get; set; } = string.Empty; // "Masculino" ou "Feminino"
        public int Idade { get; set; }
        public double Peso { get; set; }

        // Dobras enviadas com chave e valor
        public Dictionary<string, double> Dobras { get; set; } = new();
    }

    public class ComposicaoCorporalResponseDTO
    {
        public double DensidadeCorporal { get; set; }
        public double PercentualGordura { get; set; }
        public double MassaGorda { get; set; }
        public double MassaMagra { get; set; }
    }
}
