﻿namespace PEACE.api.Models
{
    public class Nutricionista
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }
        public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();


    }
}