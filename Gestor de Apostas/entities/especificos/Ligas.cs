using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.entrada;
using Gestor_de_Apostas.entities.ordenarFiltrar;
using System.Globalization;


namespace Gestor_de_Apostas.entities.especificos
{
    internal class Ligas
    {
        public static List<string> listaLigas { get; set; } = new List<string>();

        public void AdicionarLiga(Entrada entrada)
        {
            string novaLiga = entrada.Liga!;
            if (!listaLigas.Contains(novaLiga))
            {
                listaLigas.Add(novaLiga);
            }
        }

        public Dictionary<string, int> ContLigaCerta(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> contCerta = new Dictionary<string, int>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string liga = entrada.Liga!;
                StatusAposta resultado = entrada.Status;

                if (resultado == StatusAposta.Certa)
                {
                    if (contCerta.ContainsKey(liga))
                    {
                        contCerta[liga]++;
                    }
                    else
                    {
                        contCerta[liga] = 1;
                    }
                }
            }
            return contCerta;
        }

        public Dictionary<string, int> ContLigaErrada(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> contErrada = new Dictionary<string, int>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string liga = entrada.Liga!;
                StatusAposta resultado = entrada.Status;

                if (resultado == StatusAposta.Errada)
                {
                    if (contErrada.ContainsKey(liga))
                    {
                        contErrada[liga]++;
                    }
                    else
                    {
                        contErrada[liga] = 1;
                    }
                }
            }
            return contErrada;
        }

        public Dictionary<string, double> SaldoLigaCertas(List<Entrada> entradasFinalizadas)
        {
            Bankroll bank = new();

            Dictionary<string, double> saldoCertas = new Dictionary<string, double>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string liga = entrada.Liga!;
                double odd = entrada.Odd;
                double stake = entrada.Stake;
                StatusAposta status = entrada.Status;
                double lucro = bank.Lucro(entrada.Status, stake, odd);

                if (status == StatusAposta.Certa)
                {
                    if (saldoCertas.ContainsKey(liga))
                    {
                        saldoCertas[liga] += lucro;
                    }
                    else
                    {
                        saldoCertas[liga] = lucro;
                    }
                }
            }
            return saldoCertas;
        }

        public Dictionary<string, double> SaldoLigaErradas(List<Entrada> entradasFinalizadas)
        {
            Bankroll bank = new();

            Dictionary<string, double> saldoErradas = new Dictionary<string, double>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string liga = entrada.Liga!;
                double odd = entrada.Odd;
                double stake = entrada.Stake;
                StatusAposta status = entrada.Status;
                double lucro = bank.Lucro(entrada.Status, stake, odd);

                if (status == StatusAposta.Errada)
                {
                    if (saldoErradas.ContainsKey(liga))
                    {
                        saldoErradas[liga] += lucro;
                    }
                    else
                    {
                        saldoErradas[liga] = lucro;
                    }
                }
            }
            return saldoErradas;
        }

        public void ExibirListaLiga()
        {
            Dictionary<string, int> jogoLigaCerta = ContLigaCerta(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, int> jogoLigaErrada = ContLigaErrada(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, double> saldoLigaCerta = SaldoLigaCertas(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, double> saldoLigaErrada = SaldoLigaErradas(ApostasFinalizadas.entradasFinalizadas);

            Console.Clear();

            Console.WriteLine("                        |            Jogos            |                    Saldo                   |    WinRate   |");
            Console.WriteLine("------------------------|-----------------------------|--------------------------------------------|--------------|");

            Console.WriteLine(" Nº |       Ligas       | Certas  | Erradas |  Total  |    Certas    |    Erradas   |     Total    | Acertividade | ");
            Console.WriteLine("----|-------------------|---------|---------|---------|--------------|--------------|--------------|--------------|");

            int index = 1;
            listaLigas = LinqOrder.OrdenarLiga(listaLigas);

            foreach (string liga in listaLigas)
            {

                int jogosCerta = jogoLigaCerta.ContainsKey(liga) ? jogoLigaCerta[liga] : 0;
                int jogosErrada = jogoLigaErrada.ContainsKey(liga) ? jogoLigaErrada[liga] : 0;
                int totalJogos = jogosCerta + jogosErrada;

                double winRate = jogosCerta / (double)totalJogos * 100;
                string winRateVisualizar = winRate.ToString("N2") + "%";

                double saldoCerta = saldoLigaCerta.ContainsKey(liga) ? saldoLigaCerta[liga] : 0;
                double saldoErrada = saldoLigaErrada.ContainsKey(liga) ? saldoLigaErrada[liga] : 0;
                double saldoTotal = saldoCerta + saldoErrada;

                Console.WriteLine($" {index}  | " +
                                  $"{liga.PadRight(14).PadLeft(17)} | " +
                                  $"{jogosCerta.ToString().PadRight(4).PadLeft(7)} | " +
                                  $"{jogosErrada.ToString().PadRight(4).PadLeft(7)} | " +
                                  $"{totalJogos.ToString().PadRight(4).PadLeft(7)} | " +
                                  $"{saldoCerta.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                                  $"{saldoErrada.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                                  $"{saldoTotal.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                                  $"{winRateVisualizar.PadRight(10).PadLeft(12)} |");

                Console.WriteLine("----|-------------------|---------|---------|---------|--------------|--------------|--------------|--------------|");

                index++;
            }
        }
    }
}

