using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.entrada;
using Gestor_de_Apostas.entities.ordenarFiltrar;
using System.Globalization;


namespace Gestor_de_Apostas.entities.especificos
{
    internal class Equipes
    {
        public static List<string> listaTimes { get; set; } = new List<string>();

        public void AdicicionarTime(Entrada entrada)
        {
            string novoTime = entrada.TimeA;
            if (!listaTimes.Contains(novoTime))
            {
                listaTimes.Add(entrada.TimeA);
            }
            string novoTime2 = entrada.TimeB;
            if (!listaTimes.Contains(novoTime2))
            {
                listaTimes.Add(entrada.TimeB);
            }
        }

        public Dictionary<string, int> ObterJogosCasa(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> jogosCasa = new Dictionary<string, int>();
            foreach (Entrada entrada in entradasFinalizadas)
            {
                if (jogosCasa.ContainsKey(entrada.TimeA))
                {
                    jogosCasa[entrada.TimeA]++;
                }
                else
                {
                    jogosCasa[entrada.TimeA] = 1;
                }
            }
            return jogosCasa;
        }

        public Dictionary<string, int> ObterJogosVisitante(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> jogosVisitante = new Dictionary<string, int>();
            foreach (Entrada entrada in entradasFinalizadas)
            {
                if (jogosVisitante.ContainsKey(entrada.TimeB))
                {
                    jogosVisitante[entrada.TimeB]++;
                }
                else
                {
                    jogosVisitante[entrada.TimeB] = 1;
                }
            }
            return jogosVisitante;
        }

        public Dictionary<string, double> ObterGanhosApostasCasa(List<Entrada> entradasFinalizadas)
        {
            Bankroll bank = new Bankroll();

            Dictionary<string, double> saldoCasa = new Dictionary<string, double>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string timeA = entrada.TimeA;
                double odd = entrada.Odd;
                double stake = entrada.Stake;
                double lucro = bank.Lucro(entrada.Status, stake, odd);

                if (saldoCasa.ContainsKey(timeA))
                {
                    saldoCasa[timeA] += lucro;
                }
                else
                {
                    saldoCasa[timeA] = lucro;
                }
            }
            return saldoCasa;
        }

        public Dictionary<string, double> ObterGanhosApostasVisitante(List<Entrada> entradasFinalizadas)
        {
            Bankroll bank = new Bankroll();

            Dictionary<string, double> saldoVisitante = new Dictionary<string, double>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string timeB = entrada.TimeB;
                double odd = entrada.Odd;
                double stake = entrada.Stake;
                double lucro = bank.Lucro(entrada.Status, stake, odd);

                if (saldoVisitante.ContainsKey(timeB))
                {
                    saldoVisitante[timeB] += lucro;
                }
                else
                {
                    saldoVisitante[timeB] = lucro;
                }
            }
            return saldoVisitante;

        }

        public Dictionary<string, int> ContarApostasCertasCasa(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> apostasCertas = new Dictionary<string, int>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string timeCasa = entrada.TimeA;
                StatusAposta resultado = entrada.Status;

                if (resultado == StatusAposta.Certa)
                {
                    if (apostasCertas.ContainsKey(timeCasa))
                    {
                        apostasCertas[timeCasa]++;
                    }
                    else
                    {
                        apostasCertas[timeCasa] = 1;
                    }
                }
            }
            return apostasCertas;
        }

        public Dictionary<string, int> ContarApostasCertasVisitante(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> apostasCertas = new Dictionary<string, int>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string timeVisitante = entrada.TimeB!;
                StatusAposta resultado = entrada.Status;

                if (resultado == StatusAposta.Certa)
                {
                    if (apostasCertas.ContainsKey(timeVisitante))
                    {
                        apostasCertas[timeVisitante]++;
                    }
                    else
                    {
                        apostasCertas[timeVisitante] = 1;
                    }
                }
            }
            return apostasCertas;
        }

        public Dictionary<string, int> ContarApostasErradasCasa(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> apostasErradas = new Dictionary<string, int>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string timeCasa = entrada.TimeA;
                StatusAposta resultado = entrada.Status;

                if (resultado == StatusAposta.Errada)
                {
                    if (apostasErradas.ContainsKey(timeCasa))
                    {
                        apostasErradas[timeCasa]++;
                    }
                    else
                    {
                        apostasErradas[timeCasa] = 1;
                    }
                }
            }
            return apostasErradas;
        }

        public Dictionary<string, int> ContarApostasErradasVisitante(List<Entrada> entradasFinalizadas)
        {
            Dictionary<string, int> apostasErradas = new Dictionary<string, int>();

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string timeVisitante = entrada.TimeB!;
                StatusAposta resultado = entrada.Status;

                if (resultado == StatusAposta.Errada)
                {
                    if (apostasErradas.ContainsKey(timeVisitante))
                    {
                        apostasErradas[timeVisitante]++;
                    }
                    else
                    {
                        apostasErradas[timeVisitante] = 1;
                    }
                }
            }
            return apostasErradas;
        }

        public void ExibirListaTime(List<string> listaTimes)
        {
            Console.Clear();

            Console.WriteLine("                         |          Jogos        |        Acertos        |        Erradas        |               WinRate               |                   Saldo                    |");
            Console.WriteLine("-------------------------|-----------------------|-----------------------|-----------------------|-------------------------------------|--------------------------------------------|");

            Console.WriteLine(" Nº |       Equipes      |  Casa |  Fora | Total |  Casa |  Fora | Total |  Casa |  Fora | Total |    Casa   |    Fora    |    Total   |     Casa     |     Fora     |     Total    |");
            Console.WriteLine("----|--------------------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-----------|------------|------------|--------------|--------------|--------------|");


            Dictionary<string, int> jogosCasa = ObterJogosCasa(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, int> jogosVisitante = ObterJogosVisitante(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, double> saldoCasa = ObterGanhosApostasCasa(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, double> saldoVisitante = ObterGanhosApostasVisitante(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, int> acertosCasa = ContarApostasCertasCasa(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, int> acertosVisitante = ContarApostasCertasVisitante(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, int> errosCasa = ContarApostasErradasCasa(ApostasFinalizadas.entradasFinalizadas);
            Dictionary<string, int> errosVisitante = ContarApostasErradasVisitante(ApostasFinalizadas.entradasFinalizadas);

            int index = 1;
            listaTimes = LinqOrder.OrdenarTime(listaTimes);

            foreach (string equipe in listaTimes)
            {
                //Conta jogos
                int jogosCasaEquipe = jogosCasa.ContainsKey(equipe) ? jogosCasa[equipe] : 0;
                int jogosVisitanteEquipe = jogosVisitante.ContainsKey(equipe) ? jogosVisitante[equipe] : 0;
                int totalJogos = jogosCasaEquipe + jogosVisitanteEquipe;

                // Acertos & Erros
                int acertosCasaEquipe = acertosCasa.ContainsKey(equipe) ? acertosCasa[equipe] : 0;
                int acertosVisitanteEquipe = acertosVisitante.ContainsKey(equipe) ? acertosVisitante[equipe] : 0;
                int totalAcertos = acertosCasaEquipe + acertosVisitanteEquipe;

                int errosCasaEquipe = errosCasa.ContainsKey(equipe) ? errosCasa[equipe] : 0;
                int errosVisitanteEquipe = errosVisitante.ContainsKey(equipe) ? errosVisitante[equipe] : 0;
                int totalErros = errosCasaEquipe + errosVisitanteEquipe;

                double totalCasa = acertosCasaEquipe + errosCasaEquipe;
                double totalVisitante = acertosVisitanteEquipe + errosVisitanteEquipe;

                // WinRate
                double winRateCasa = totalCasa != 0 ? acertosCasaEquipe / totalCasa * 100 : 0;
                double winRateVisitante = totalVisitante != 0 ? acertosVisitanteEquipe / totalVisitante * 100 : 0;

                double winRate = totalAcertos / (double)totalJogos * 100;

                string winRatePorcentagemCasa = winRateCasa.ToString("N1") + "%";
                string winRatePorcentagemVisitante = winRateVisitante.ToString("N1") + "%";
                string mediaWinrateTotal = winRate.ToString("N1") + "%";

                //Saldo
                double saldoEquipeCasa = saldoCasa.ContainsKey(equipe) ? saldoCasa[equipe] : 0;
                double saldoEquipeVisitante = saldoVisitante.ContainsKey(equipe) ? saldoVisitante[equipe] : 0;

                double totalSaldo = saldoEquipeCasa + saldoEquipeVisitante;

                Console.WriteLine($" {index}  | {equipe.PadRight(14).PadLeft(18)} | " +
                                    $"{jogosCasaEquipe.ToString().PadRight(3).PadLeft(5)} | " +
                                    $"{jogosVisitanteEquipe.ToString().PadRight(3).PadLeft(5)} | " +
                                    $"{totalJogos.ToString().PadRight(3).PadLeft(5)} | " +
                                    $"{acertosCasaEquipe.ToString().PadRight(3).PadLeft(5)} | " +
                                    $"{acertosVisitanteEquipe.ToString().PadRight(3).PadLeft(5)} | " +
                                    $"{totalAcertos.ToString().PadRight(3).PadLeft(5)} | " +
                                    $"{errosCasaEquipe.ToString().PadRight(3).PadLeft(5)} | " +
                                    $"{errosVisitanteEquipe.ToString().PadRight(3).PadLeft(5)} | " +
                                    $"{totalErros.ToString().PadRight(3).PadLeft(5)} |" +
                                    $"{winRatePorcentagemCasa.PadRight(8).PadLeft(10)} | " +
                                    $"{winRatePorcentagemVisitante.PadRight(8).PadLeft(10)} | " +
                                    $"{mediaWinrateTotal.PadRight(8).PadLeft(10)} | " +
                                    $"{saldoEquipeCasa.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                                    $"{saldoEquipeVisitante.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                                    $"{totalSaldo.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} |");

                Console.WriteLine("----|--------------------|-------|-------|-------|-------|-------|-------|-------|-------|-------|-----------|------------|------------|--------------|--------------|--------------|");

                index++;
            }
        }
    }
}
