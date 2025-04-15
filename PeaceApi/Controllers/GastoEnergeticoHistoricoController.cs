using Microsoft.AspNetCore.Mvc;
using PEACE.api.DTOs;
using PEACE.api.Services;
using PEACE.api.Models;

namespace PEACE.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastoEnergeticoHistoricoController : ControllerBase
    {
        private readonly GastoEnergeticoHistoricoService _service;

        public GastoEnergeticoHistoricoController(GastoEnergeticoHistoricoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<GastoEnergeticoHistorico>> Registrar([FromBody] RegistrarGastoEnergeticoDTO dto)
        {
            var resultado = await _service.RegistrarHistoricoAsync(dto);
            return Ok(resultado);
        }

        [HttpGet("{pacienteId}")]
        public async Task<ActionResult<IEnumerable<GastoEnergeticoHistoricoDTO>>> Listar(int pacienteId)
        {
            var lista = await _service.ListarPorPacienteAsync(pacienteId);
            return Ok(lista);
        }
    }
}