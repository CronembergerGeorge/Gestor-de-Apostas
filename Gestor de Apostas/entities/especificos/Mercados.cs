using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.entrada;
using Gestor_de_Apostas.entities.ordenarFiltrar;
using System.Globalization;

namespace Gestor_de_Apostas.entities.especificos
{
    internal class Mercados
    {
        public static List<string> listaMercado { get; set; } = new List<string>();

        public void AdicionarMercado(Entrada entrada)
        {
            string novoMercado = entrada.Mercado!;
            if (!listaMercado.Contains(novoMercado))
            {
                listaMercado.Add(novoMercado);
            }
        }

        public Dictionary<string, int> ContMercadoCerta(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> contCerta = new Dictionary<string, int>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string mercado = entrada.Mercado!;
                StatusAposta resultado = entrada.Status;

                if (resultado == StatusAposta.Certa)
                {
                    if (contCerta.ContainsKey(mercado))
                    {
                        contCerta[mercado]++;
                    }
                    else
                    {
                        contCerta[mercado] = 1;
                    }
                }
            }
            return contCerta;
        }

        public Dictionary<string, int> ContMercadoErrada(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> contErrada = new Dictionary<string, int>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string mercado = entrada.Mercado!;
                StatusAposta resultado = entrada.Status;

                if (resultado == StatusAposta.Errada)
                {
                    if (contErrada.ContainsKey(mercado))
                    {
                        contErrada[mercado]++;
                    }
                    else
                    {
                        contErrada[mercado] = 1;
                    }
                }
            }
            return contErrada;
        }

        public Dictionary<string, double> SaldoMercadoCertas(List<Entrada> entradasFinalizadas)
        {
            Bankroll bank = new();

            Dictionary<string, double> saldoCertas = new Dictionary<string, double>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string mercado = entrada.Mercado!;
                double odd = entrada.Odd;
                double stake = entrada.Stake;
                StatusAposta status = entrada.Status;
                double lucro = bank.Lucro(entrada.Status, stake, odd);

                if (status == StatusAposta.Certa)
                {
                    if (saldoCertas.ContainsKey(mercado))
                    {
                        saldoCertas[mercado] += lucro;
                    }
                    else
                    {
                        saldoCertas[mercado] = lucro;
                    }
                }

            }
            return saldoCertas;
        }

        public Dictionary<string, double> SaldoMercadoErradas(List<Entrada> entradasFinalizadas)
        {
            Bankroll bank = new();

            Dictionary<string, double> saldoErradas = new Dictionary<string, double>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string mercado = entrada.Mercado!;
                double odd = entrada.Odd;
                double stake = entrada.Stake;
                StatusAposta status = entrada.Status;
                double lucro = bank.Lucro(entrada.Status, stake, odd);

                if (status == StatusAposta.Errada)
                {
                    if (saldoErradas.ContainsKey(mercado))
                    {
                        saldoErradas[mercado] += lucro;
                    }
                    else
                    {
                        saldoErradas[mercado] = lucro;
                    }
                }
            }
            return saldoErradas;
        }

        public void ExibirListaMercado()
        {
            ApostasFinalizadas apostas = new();
            Dictionary<string, int> jogoMercadoCerta = ContMercadoCerta(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, int> jogoMercadoErrada = ContMercadoErrada(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, double> saldoMercadoCerta = SaldoMercadoCertas(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, double> saldoMercadoErrada = SaldoMercadoErradas(ApostasFinalizadas.entradasFinalizadas);

            Console.Clear();

            Console.WriteLine("                         |            Jogos            |                    Saldo                   |    WinRate    |");
            Console.WriteLine("-------------------------|-----------------------------|--------------------------------------------|---------------|");

            Console.WriteLine(" Nº |      Mercados      | Certas  | Erradas |  Total  |    Certas    |    Erradas   |     Total    | Acertividade  | ");
            Console.WriteLine("----|--------------------|---------|---------|---------|--------------|--------------|--------------|---------------|");

            int index = 1;
            listaMercado = LinqOrder.OrdenarLiga(listaMercado);

            foreach (string mercado in listaMercado)
            {
                int jogosCerta = jogoMercadoCerta.ContainsKey(mercado) ? jogoMercadoCerta[mercado] : 0;
                int jogosErrada = jogoMercadoErrada.ContainsKey(mercado) ? jogoMercadoErrada[mercado] : 0;
                int totalJogos = jogosCerta + jogosErrada;

                double winRate = jogosCerta / (double)totalJogos * 100;
                string winRateVisualizar = winRate.ToString("N2") + "%";

                double saldoCerta = saldoMercadoCerta.ContainsKey(mercado) ? saldoMercadoCerta[mercado] : 0;
                double saldoErrada = saldoMercadoErrada.ContainsKey(mercado) ? saldoMercadoErrada[mercado] : 0;
                double saldoTotal = saldoCerta + saldoErrada;

                Console.WriteLine($" {index}  | " +
                    $"{mercado.PadRight(14).PadLeft(18)} | " +
                    $"{jogosCerta.ToString().PadRight(4).PadLeft(7)} | " +
                    $"{jogosErrada.ToString().PadRight(4).PadLeft(7)} | " +
                    $"{totalJogos.ToString().PadRight(4).PadLeft(7)} | " +
                    $"{saldoCerta.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                    $"{saldoErrada.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                    $"{saldoTotal.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                    $"{winRateVisualizar.PadRight(10).PadLeft(13)} |");

                Console.WriteLine("----|--------------------|---------|---------|---------|--------------|--------------|--------------|---------------|");
                index++;
            }
        }
    }
}
