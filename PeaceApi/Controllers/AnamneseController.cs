using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PEACE.api.Data;
using PEACE.api.DTOs;
using PEACE.api.Models;

namespace PEACE.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnamneseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnamneseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<AnamneseResponseDTO>> Criar(AnamneseRequestDTO dto)
        {
            var anamnese = new Anamnese
            {
                PacienteId = dto.PacienteId,
                NomeCompleto = dto.NomeCompleto,
                DataNascimento = dto.DataNascimento,
                Ocupacao = dto.Ocupacao,
                PraticaAtividadeFisica = dto.PraticaAtividadeFisica,
                AtividadeFisicaTipo = dto.AtividadeFisicaTipo,
                AtividadeFisicaHorario = dto.AtividadeFisicaHorario,
                AtividadeFisicaFrequencia = dto.AtividadeFisicaFrequencia,

                HistoricoFamiliar_HAS = dto.HistoricoFamiliar_HAS,
                HistoricoFamiliar_DM = dto.HistoricoFamiliar_DM,
                HistoricoFamiliar_Hipercolesterolemia = dto.HistoricoFamiliar_Hipercolesterolemia,
                HistoricoFamiliar_DoencaCardiaca = dto.HistoricoFamiliar_DoencaCardiaca,

                HistoricoPessoal_HAS = dto.HistoricoPessoal_HAS,
                HistoricoPessoal_DM = dto.HistoricoPessoal_DM,
                HistoricoPessoal_Hipercolesterolemia = dto.HistoricoPessoal_Hipercolesterolemia,
                HistoricoPessoal_DoencaCardiaca = dto.HistoricoPessoal_DoencaCardiaca,

                UsaMedicamento = dto.UsaMedicamento,
                Medicamentos = dto.Medicamentos,
                UsaSuplemento = dto.UsaSuplemento,
                Suplementos = dto.Suplementos,
                TemAlergiaAlimentar = dto.TemAlergiaAlimentar,
                Alergias = dto.Alergias,
                IntoleranciaLactose = dto.IntoleranciaLactose,
                AversoesAlimentares = dto.AversoesAlimentares,
                ConsumoAguaDiario = dto.ConsumoAguaDiario,
                FrequenciaIntestinal = dto.FrequenciaIntestinal
            };

            _context.Add(anamnese);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = anamnese.Id }, MapearParaResponse(anamnese));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnamneseResponseDTO>> ObterPorId(int id)
        {
            var anamnese = await _context.Set<Anamnese>().FirstOrDefaultAsync(a => a.Id == id);
            if (anamnese == null) return NotFound();

            return MapearParaResponse(anamnese);
        }

        [HttpGet("paciente/{pacienteId}")]
        public async Task<ActionResult<IEnumerable<AnamneseResponseDTO>>> ObterPorPaciente(int pacienteId)
        {
            var lista = await _context.Set<Anamnese>()
                .Where(a => a.PacienteId == pacienteId)
                .OrderByDescending(a => a.DataNascimento)
                .ToListAsync();

            return lista.Select(MapearParaResponse).ToList();
        }

        private AnamneseResponseDTO MapearParaResponse(Anamnese a) => new()
        {
            Id = a.Id,
            PacienteId = a.PacienteId,
            NomeCompleto = a.NomeCompleto,
            DataNascimento = a.DataNascimento,
            Idade = a.Idade,
            Ocupacao = a.Ocupacao,
            PraticaAtividadeFisica = a.PraticaAtividadeFisica,
            AtividadeFisicaTipo = a.AtividadeFisicaTipo,
            AtividadeFisicaHorario = a.AtividadeFisicaHorario,
            AtividadeFisicaFrequencia = a.AtividadeFisicaFrequencia,

            HistoricoFamiliar_HAS = a.HistoricoFamiliar_HAS,
            HistoricoFamiliar_DM = a.HistoricoFamiliar_DM,
            HistoricoFamiliar_Hipercolesterolemia = a.HistoricoFamiliar_Hipercolesterolemia,
            HistoricoFamiliar_DoencaCardiaca = a.HistoricoFamiliar_DoencaCardiaca,

            HistoricoPessoal_HAS = a.HistoricoPessoal_HAS,
            HistoricoPessoal_DM = a.HistoricoPessoal_DM,
            HistoricoPessoal_Hipercolesterolemia = a.HistoricoPessoal_Hipercolesterolemia,
            HistoricoPessoal_DoencaCardiaca = a.HistoricoPessoal_DoencaCardiaca,

            UsaMedicamento = a.UsaMedicamento,
            Medicamentos = a.Medicamentos,
            UsaSuplemento = a.UsaSuplemento,
            Suplementos = a.Suplementos,
            TemAlergiaAlimentar = a.TemAlergiaAlimentar,
            Alergias = a.Alergias,
            IntoleranciaLactose = a.IntoleranciaLactose,
            AversoesAlimentares = a.AversoesAlimentares,
            ConsumoAguaDiario = a.ConsumoAguaDiario,
            FrequenciaIntestinal = a.FrequenciaIntestinal
        };
    }
}