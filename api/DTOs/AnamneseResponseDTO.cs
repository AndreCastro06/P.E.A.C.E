using PEACE.api.Enums;

namespace PEACE.api.DTOs
{
    public class AnamneseResponseDTO : AnamneseRequestDTO
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public int Idade { get; set; } 
    }
}