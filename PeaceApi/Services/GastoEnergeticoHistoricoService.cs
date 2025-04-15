using PEACE.api.DTOs;
using PEACE.api.Enums;
using PEACE.api.Models;
using PEACE.api.Data;
using Microsoft.EntityFrameworkCore;

namespace PEACE.api.Services
{
    public class GastoEnergeticoHistoricoService
    {
        private readonly AppDbContext _context;

        public GastoEnergeticoHistoricoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GastoEnergeticoHistorico> RegistrarHistoricoAsync(RegistrarGastoEnergeticoDTO dto)
        {
            double geb = 0;

            if (dto.Protocolo == ProtocoloGEB.HarrisBenedict)
            {
                geb = dto.Sexo == Sexo.Masculino
                    ? 66.47 + (13.75 * dto.Peso) + (5.0 * dto.Altura) - (6.76 * dto.Idade)
                    : 655.1 + (9.56 * dto.Peso) + (1.85 * dto.Altura) - (4.68 * dto.Idade);
            }
            else if (dto.Protocolo == ProtocoloGEB.MifflinStJeor)
            {
                geb = dto.Sexo == Sexo.Masculino
                    ? (10 * dto.Peso) + (6.25 * dto.Altura) - (5 * dto.Idade) + 5
                    : (10 * dto.Peso) + (6.25 * dto.Altura) - (5 * dto.Idade) - 161;
            }

            double get = geb * ((double)dto.FatorAtividade / 100);

            var historico = new GastoEnergeticoHistorico
            {
                PacienteId = dto.PacienteId,
                Protocolo = dto.Protocolo,
                Sexo = dto.Sexo,
                Peso = dto.Peso,
                Altura = dto.Altura,
                Idade = dto.Idade,
                FatorAtividade = dto.FatorAtividade,
                GEB = Math.Round(geb, 2),
                GET = Math.Round(get, 2),
                DataCalculo = DateTime.UtcNow
            };

            _context.GastoEnergeticoHistorico.Add(historico);
            await _context.SaveChangesAsync();

            return historico;
        }

        public async Task<List<GastoEnergeticoHistoricoDTO>> ListarPorPacienteAsync(int pacienteId)
        {
            return await _context.GastoEnergeticoHistorico
                .Where(h => h.PacienteId == pacienteId)
                .OrderByDescending(h => h.DataCalculo)
                .Select(h => new GastoEnergeticoHistoricoDTO
                {
                    Id = h.Id,
                    Protocolo = h.Protocolo,
                    Sexo = h.Sexo,
                    FatorAtividade = h.FatorAtividade,
                    Peso = h.Peso,
                    Altura = h.Altura,
                    Idade = h.Idade,
                    GEB = h.GEB,
                    GET = h.GET,
                    DataCalculo = h.DataCalculo
                })
                .ToListAsync();
        }
    }
}