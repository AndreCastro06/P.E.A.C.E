using Microsoft.AspNetCore.Mvc;
using PEACE.api.DTOs;
using PEACE.api.Services;

namespace PEACE.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculoGastoEnergeticoController : ControllerBase
    {
        private readonly CalculoGastoEnergeticoService _service;

        public CalculoGastoEnergeticoController()
        {
            _service = new CalculoGastoEnergeticoService(); 
        }

        [HttpPost("calcular")]
        public ActionResult<ResultadoCalculoGETDTO> Calcular([FromBody] CalculoGEBDTO dto)
        {
            try
            {
                var resultado = _service.CalcularGEBEGET(dto);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}