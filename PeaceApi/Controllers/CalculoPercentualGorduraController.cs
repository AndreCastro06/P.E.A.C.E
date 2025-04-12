using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEACE.api.Data;
using PEACE.api.DTOs;
using PEACE.api.Models;
using PEACE.api.Services;

namespace PEACE.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComposicaoCorporalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComposicaoCorporalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("calcular")]
        [Authorize(Roles = "Nutricionista")]
        public ActionResult<ComposicaoCorporalResponseDTO> Calcular(ComposicaoCorporalRequestDTO dto)
        {
            try
            {
                var densidade = ComposicaoCorporalService.CalcularDensidadeCorporal(dto.Metodo, dto.Sexo, dto.Idade, dto.Dobras);
                var percGordura = ComposicaoCorporalService.CalcularPercentualGordura(densidade);
                var massaGorda = ComposicaoCorporalService.CalcularMassaGorda(dto.Peso, percGordura);
                var massaMagra = ComposicaoCorporalService.CalcularMassaMagra(dto.Peso, massaGorda);

                return new ComposicaoCorporalResponseDTO
                {
                    DensidadeCorporal = Math.Round(densidade, 4),
                    PercentualGordura = Math.Round(percGordura, 2),
                    MassaGorda = Math.Round(massaGorda, 2),
                    MassaMagra = Math.Round(massaMagra, 2)
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("paciente/{pacienteId}")]
        [Authorize(Roles = "Nutricionista")]
        public async Task<ActionResult<IEnumerable<AvaliacaoFisica>>> CompararAvaliacoes(
            int pacienteId,
            [FromQuery] DateTime? dataInicio,
            [FromQuery] DateTime? dataFim)
        {
            var query = _context.Set<AvaliacaoFisica>()
                .Include(a => a.PregasCutaneas)
                .Where(a => a.PacienteId == pacienteId);

            if (dataInicio.HasValue)
                query = query.Where(a => a.DataAvaliacao >= dataInicio.Value);

            if (dataFim.HasValue)
                query = query.Where(a => a.DataAvaliacao <= dataFim.Value);

            var avaliacoes = await query.OrderBy(a => a.DataAvaliacao).ToListAsync();

            return avaliacoes;
        }
    }
}

