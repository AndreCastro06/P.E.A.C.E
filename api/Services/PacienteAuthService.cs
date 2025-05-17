using Microsoft.EntityFrameworkCore;
using PEACE.api.Data;
using PEACE.api.DTOs;
using PEACE.api.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace PEACE.api.Services
{
    public class PacienteAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public PacienteAuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Paciente?> RegisterAsync(RegisterPacienteDTO dto)
        {
            if (await _context.Pacientes.AnyAsync(p => p.Email == dto.Email))
                return null;

            PasswordHasher.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

            var paciente = new Paciente
            {
                NomeCompleto = dto.NomeCompleto,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
                NutricionistaId = null
            };

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }

        public async Task<LoginResponseDTO?> LoginAsync(LoginDTO dto)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (paciente == null || paciente.PasswordHash == null || paciente.PasswordSalt == null)
                return null;

            bool isValid = PasswordHasher.VerifyPasswordHash(dto.Password, paciente.PasswordHash, paciente.PasswordSalt);

            if (!isValid)
                return null;

            var token = GerarTokenJwt(paciente);

            return new LoginResponseDTO
            {
                Token = token,
                Nome = paciente.NomeCompleto,
                Role = "Paciente"
            };
        }

        private string GerarTokenJwt(Paciente paciente)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", paciente.Id.ToString()),
                    new Claim(ClaimTypes.Name, paciente.NomeCompleto),
                    new Claim(ClaimTypes.Role, "Paciente")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}