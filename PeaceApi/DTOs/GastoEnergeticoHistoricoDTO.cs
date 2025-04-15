using PEACE.api.Enums;

namespace PEACE.api.DTOs
{
    public class GastoEnergeticoHistoricoDTO
    {
        public int Id { get; set; }
        public ProtocoloGEB Protocolo { get; set; }
        public Sexo Sexo { get; set; }
        public FatorAtividade FatorAtividade { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public int Idade { get; set; }
        public double GEB { get; set; }
        public double GET { get; set; }
        public DateTime DataCalculo { get; set; }
    }

}
