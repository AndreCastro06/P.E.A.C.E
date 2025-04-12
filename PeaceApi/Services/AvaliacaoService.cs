using PEACE.api.DTOs;
using PEACE.api.Models;

namespace PEACE.api.Services
{
    public class AvaliacaoService
    {
        public ResultadoAvaliacaoDTO CalcularResultado(AvaliacaoAntropometricaDTO dto)
        {
            double peso = dto.PesoEmLibras ? dto.Peso * 0.453592 : dto.Peso;
            double percentualGordura = 0;
            double somaDobras = 0;
            double densidade = 0;

            switch (dto.Metodo)
            {
                case MetodoAvaliacao.Faulkner:
                    somaDobras = dto.Tricipital + dto.Subescapular + dto.Suprailiaca + dto.Abdominal;
                    percentualGordura = (somaDobras * 0.153) + 5.783;
                    break;

                case MetodoAvaliacao.JacksonPollock3Dobras:
                    if (dto.Sexo.ToLower() == "masculino")
                    {
                        somaDobras = dto.Peitoral + dto.Abdominal + dto.Coxa;
                        densidade = 1.10938 - (0.0008267 * somaDobras) + (0.0000016 * Math.Pow(somaDobras, 2)) - (0.0002574 * dto.Idade);
                    }
                    else
                    {
                        somaDobras = dto.Tricipital + dto.Suprailiaca + dto.Coxa;
                        densidade = 1.0994921 - (0.0009929 * somaDobras) + (0.0000023 * Math.Pow(somaDobras, 2)) - (0.0001392 * dto.Idade);
                    }
                    percentualGordura = ((4.95 / densidade) - 4.5) * 100;
                    break;

                case MetodoAvaliacao.JacksonPollock7Dobras:
                    somaDobras = dto.Tricipital + dto.Subescapular + dto.Peitoral + dto.Abdominal + dto.Suprailiaca + dto.Axilar + dto.Coxa;
                    densidade = dto.Sexo.ToLower() == "masculino"
                        ? 1.112 - (0.00043499 * somaDobras) + (0.00000055 * Math.Pow(somaDobras, 2)) - (0.00028826 * dto.Idade)
                        : 1.097 - (0.00042041 * somaDobras) + (0.00000058 * Math.Pow(somaDobras, 2)) - (0.0002166 * dto.Idade);
                    percentualGordura = ((4.95 / densidade) - 4.5) * 100;
                    break;

                case MetodoAvaliacao.DurninWomersley:
                    somaDobras = dto.Tricipital + dto.Bicipital + dto.Subescapular + dto.Suprailiaca;
                    double logSoma = Math.Log10(somaDobras);
                    densidade = dto.Sexo.ToLower() == "masculino"
                        ? 1.1631 - (0.0632 * logSoma)
                        : 1.1599 - (0.0717 * logSoma);
                    percentualGordura = ((4.95 / densidade) - 4.5) * 100;
                    break;

                case MetodoAvaliacao.Guedes:
                    somaDobras = dto.Tricipital + dto.Subescapular + dto.Suprailiaca + dto.Panturrilha;
                    percentualGordura = dto.Sexo.ToLower() == "masculino"
                        ? (0.61 * somaDobras) - (0.16 * dto.Idade) + 3.8
                        : (0.55 * somaDobras) - (0.14 * dto.Idade) + 5.8;
                    break;

                default:
                    throw new ArgumentException("Método de avaliação inválido.");
            }

            double massaGorda = (peso * percentualGordura) / 100;
            double massaMagra = peso - massaGorda;

            double tmb = dto.Sexo.ToLower() == "masculino"
                ? (10 * peso) + (6.25 * dto.Altura) - (5 * dto.Idade) + 5
                : (10 * peso) + (6.25 * dto.Altura) - (5 * dto.Idade) - 161;

            return new ResultadoAvaliacaoDTO
            {
                PercentualGordura = Math.Round(percentualGordura, 2),
                MassaGorda = Math.Round(massaGorda, 2),
                MassaMagra = Math.Round(massaMagra, 2),
                TMB = Math.Round(tmb, 2)
            };
        }
    }
}