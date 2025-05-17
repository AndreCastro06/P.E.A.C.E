
using System.ComponentModel.DataAnnotations;

namespace PEACE.api.DTOs
{
    public class RegisterPacienteDTO
    {
        [Required]
        public string ? NomeCompleto { get; set; }

        [Required]
        [EmailAddress]
        public string ? Email { get; set; }

        [Required]
        [MinLength(6)]
        public string ? Password { get; set; }
    }
}