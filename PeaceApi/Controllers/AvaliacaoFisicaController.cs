
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEACE.api.Data;
using PEACE.api.Models;

namespace PEACE.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoFisicaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AvaliacaoFisicaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("paciente/{pacienteId}")]
        [Authorize(Roles = "Nutricionista")]
        public async Task<ActionResult<IEnumerable<AvaliacaoFisica>>> GetPorPaciente(int pacienteId)
        {
            return await _context.Set<AvaliacaoFisica>()
                .Where(a => a.PacienteId == pacienteId)
                .OrderByDescending(a => a.DataAvaliacao)
                .ToListAsync();
        }

        [HttpPost]
        [Authorize(Roles = "Nutricionista")]
        public async Task<ActionResult<AvaliacaoFisica>> Criar(AvaliacaoFisica avaliacao)
        {
            _context.Set<AvaliacaoFisica>().Add(avaliacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPorPaciente), new { pacienteId = avaliacao.PacienteId }, avaliacao);
        }
    }
}