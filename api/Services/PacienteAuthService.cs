using PEACE.api.Models;
using PEACE.api.DTOs;
using Microsoft.EntityFrameworkCore;
using PEACE.api.Data;
using System;

namespace PEACE.api.Services;

public class PacienteAuthService
{
    private readonly AppDbContext _context;

    public PacienteAuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Paciente?> RegisterAsync(RegisterDTO dto)
    {
        if (_context.Pacientes.Any(u => u.Email == dto.Email))
            return null;

        PasswordHasher.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

        var paciente = new Paciente
        {
            Nome = dto.Nome,
            Email = dto.Email,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();

        return paciente;
    }

    public async Task<Paciente?> LoginAsync(LoginDTO dto)
    {
        var attempt = await _context.LoginAttempts.FirstOrDefaultAsync(a => a.Email == dto.Email);

        if (attempt != null && attempt.LockoutEnd.HasValue && attempt.LockoutEnd > DateTime.UtcNow)
        {
            return null; // Está bloqueado
        }

        var paciente = await _context.Pacientes.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (paciente == null || paciente.PasswordHash == null || paciente.PasswordSalt == null)
            return await RegisterFail(dto.Email);

        bool isValid = PasswordHasher.VerifyPasswordHash(dto.Password, paciente.PasswordHash, paciente.PasswordSalt);

        if (!isValid)
            return await RegisterFail(dto.Email);

        // Sucesso no login → limpar tentativas
        if (attempt != null)
            _context.LoginAttempts.Remove(attempt);

        await _context.SaveChangesAsync();
        return paciente;
    }

    private async Task<Paciente?> RegisterFail(string email)
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