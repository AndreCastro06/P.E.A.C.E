using Microsoft.AspNetCore.Mvc;
using PEACE.api.DTOs;
using PEACE.api.Models;
using PEACE.api.Services;

namespace PEACE.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly AvaliacaoService _avaliacaoService;

        public AvaliacaoController(AvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost]
        public IActionResult Avaliar([FromBody] AvaliacaoAntropometricaDTO dto)
        {
            if (dto == null)
                return BadRequest("Dados da avaliação não informados.");

            if (string.IsNullOrWhiteSpace(dto.Sexo) || dto.Idade <= 0 || dto.Peso <= 0 || dto.Altura <= 0)
                return BadRequest("Preencha sexo, idade, peso e altura corretamente.");

            if (!dto.Metodo.HasValue || dto.Metodo.Value == MetodoAvaliacao.Desconhecido)
                return BadRequest("Informe o método de avaliação para o calculo.");

            var resultado = _avaliacaoService.CalcularResultado(dto);

            return Ok(resultado);
        }
    }
}