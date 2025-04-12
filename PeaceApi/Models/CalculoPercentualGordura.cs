using PEACE.api.Models;

namespace PEACE.api.Services
{
    public static class ComposicaoCorporalService
    {
        public static double CalcularDensidadeCorporal(
            MetodoAvaliacao metodo,
            string sexo,
            int idade,
            Dictionary<string, double> dobras)
        {
            double d = 0;
            switch (metodo)
            {
                case MetodoAvaliacao.JacksonPollock3Dobras:
                    if (sexo == "Masculino")
                    {
                        var soma = dobras["PCB"] + dobras["PCAB"] + dobras["PCOX"];
                        d = 1.10938 - (0.0008267 * soma) + (0.0000016 * Math.Pow(soma, 2)) - (0.0002574 * idade);
                    }
                    else
                    {
                        var soma = dobras["PCT"] + dobras["PCSI"] + dobras["PCOX"];
                        d = 1.0994921 - (0.0009929 * soma) + (0.0000023 * Math.Pow(soma, 2)) - (0.0001392 * idade);
                    }
                    break;

                case MetodoAvaliacao.JacksonPollock7Dobras:
                    var soma7 = dobras.Values.Sum();
                    if (sexo == "Masculino")
                        d = 1.112 - (0.00043499 * soma7) + (0.00000055 * Math.Pow(soma7, 2)) - (0.00028826 * idade);
                    else
                        d = 1.097 - (0.00046971 * soma7) + (0.00000056 * Math.Pow(soma7, 2)) - (0.00012828 * idade);
                    break;

                case MetodoAvaliacao.DurninWomersley:
                    var somaDW = dobras["PCT"] + dobras["PSE"] + dobras["PCSI"] + dobras["PBI"];
                    d = TabelaDurninWomersley(idade, sexo, somaDW);
                    break;

                case MetodoAvaliacao.Faulkner:
                    var somaF = dobras["PCT"] + dobras["PCSA"] + dobras["PCSI"] + dobras["PCAB"];
                    d = 1.0982 - (0.000815 * somaF);
                    break;

                case MetodoAvaliacao.Guedes:
                    var somaG = dobras.Values.Sum();
                    d = 1.064 - (0.00164 * somaG);
                    break;

                default:
                    throw new ArgumentException("Método de avaliação desconhecido.");
            }

            return d;
        }

        public static double CalcularPercentualGordura(double densidade)
        {
            return (495 / densidade) - 450; // Fórmula de Siri
        }

        public static double CalcularMassaGorda(double peso, double percentualGordura)
        {
            return peso * (percentualGordura / 100);
        }

        public static double CalcularMassaMagra(double peso, double massaGorda)
        {
            return peso - massaGorda;
        }

        private static double TabelaDurninWomersley(int idade, string sexo, double soma)
        {
            if (sexo == "Masculino")
            {
                if (idade < 17) return 1.1533 - (0.0643 * Math.Log10(soma));
                if (idade <= 19) return 1.1620 - (0.0630 * Math.Log10(soma));
                if (idade <= 29) return 1.1631 - (0.0632 * Math.Log10(soma));
                if (idade <= 39) return 1.1422 - (0.0544 * Math.Log10(soma));
                if (idade <= 49) return 1.1620 - (0.0700 * Math.Log10(soma));
                return 1.1715 - (0.0779 * Math.Log10(soma));
            }
            else
            {
                if (idade < 17) return 1.1369 - (0.0598 * Math.Log10(soma));
                if (idade <= 19) return 1.1549 - (0.0678 * Math.Log10(soma));
                if (idade <= 29) return 1.1599 - (0.0717 * Math.Log10(soma));
                if (idade <= 39) return 1.1423 - (0.0632 * Math.Log10(soma));
                if (idade <= 49) return 1.1333 - (0.0612 * Math.Log10(soma));
                return 1.1339 - (0.0645 * Math.Log10(soma));
            }
        }
    }
}
