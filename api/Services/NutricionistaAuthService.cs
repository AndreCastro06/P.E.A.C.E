using PEACE.api.Models;
using PEACE.api.DTOs;
using Microsoft.EntityFrameworkCore;
using PEACE.api.Data;
using System;

namespace PEACE.api.Services
{
    public class NutricionistaAuthService
    {
        private readonly AppDbContext _context;

        public NutricionistaAuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Nutricionista?> RegisterAsync(RegisterDTO dto)
        {
            if (_context.Nutricionistas.Any(u => u.Email == dto.Email))
                return null;

            PasswordHasher.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

            var nutri = new Nutricionista
            {
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            _context.Nutricionistas.Add(nutri);
            await _context.SaveChangesAsync();

            return nutri;
        }

        public async Task<Nutricionista?> LoginAsync(LoginDTO dto)
        {
            var attempt = await _context.LoginAttempts.FirstOrDefaultAsync(a => a.Email == dto.Email);


            if (attempt != null && attempt.LockoutEnd.HasValue && attempt.LockoutEnd > DateTime.UtcNow)
            {
                return null; // Está bloqueado
            }

            var nutri = await _context.Nutricionistas.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (nutri == null || nutri.PasswordHash == null || nutri.PasswordSalt == null)
                return await RegisterFail(dto.Email); // atualiza tentativas

            bool isValid = PasswordHasher.VerifyPasswordHash(dto.Password, nutri.PasswordHash, nutri.PasswordSalt);

            if (!isValid)
                return await RegisterFail(dto.Email);

            // Sucesso no login → limpar tentativas
            if (attempt != null)
                _context.LoginAttempts.Remove(attempt);

            await _context.SaveChangesAsync();
            return nutri;
        }

        private async Task<Nutricionista?> RegisterFail(string email)
        {
            var attempt = await _context.LoginAttempts.FirstOrDefaultAsync(a => a.Email == email);

            if (attempt == null)
            {
                attempt = new LoginAttempt
                {
                    Email = email,
                    FailedCount = 1,
                    LastAttempt = DateTime.UtcNow
                };
                _context.LoginAttempts.Add(attempt);
            }
            else
            {
                attempt.FailedCount++;
                attempt.LastAttempt = DateTime.UtcNow;

                if (attempt.FailedCount >= 3)
                {
                    attempt.LockoutEnd = DateTime.UtcNow.AddMinutes(5);
                }
            }

            await _context.SaveChangesAsync();
            return null;
        }
    }
}
