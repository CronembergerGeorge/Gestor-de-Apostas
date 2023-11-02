using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.entrada;
using System.Globalization;

namespace Gestor_de_Apostas.entities.ordenarFiltrar
{
    internal class LinqExibir
    {
        public static void ExibirApostasFinalizadasFiltradaTime(string nomeTime)
        {
            Bankroll bank = new Bankroll();
            List<Entrada> jogosFiltrados = LinqFilter.FiltrarTime(ApostasFinalizadas.entradasFinalizadas, nomeTime);

            if (jogosFiltrados.Count == 0)
            {
                Console.WriteLine("Nenhum jogo encontrado para esse time específico");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Esses são todos os jogos do time {nomeTime}");
                Console.WriteLine(" Nº |    Data    |  Odd  |  Stake  |     Saldo    | PL/Banca |    PL/Stake   |       Time A       | x |       Time B       |      Liga      |    Mercado    |  Status  |");
                Console.WriteLine("----|------------|-------|---------|--------------|----------|---------------|--------------------|---|--------------------|----------------|---------------|----------|");

                int index = 1;
                foreach (Entrada jogo in jogosFiltrados)
                {
                    Entrada entrada = jogo;
                    double plBank = bank.PL_Lucro(entrada.Saldo) * 100;
                    double plStake = bank.PL_Stake(entrada.Saldo, entrada.Stake) * 100;
                    string plBankPorcentagem = plBank.ToString("N2") + "%";
                    string plStakePorcentagem = plStake.ToString("N2") + "%";

                    string versus = "x";

                    Console.WriteLine($" {index}  | " +
                        $"{entrada.Data} | " +
                        $"{entrada.Odd.ToString().PadRight(3).PadLeft(5)} | " +
                        $"{entrada.Stake.ToString("C", CultureInfo.GetCultureInfo("en-GB"))} | " +
                        $"{entrada.Saldo.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                        $"{plBankPorcentagem.PadRight(7).PadLeft(8)} | " +
                        $"{plStakePorcentagem.PadRight(11).PadLeft(13)} | " +
                        $"{entrada.TimeA.PadRight(14).PadLeft(18)} | " +
                        $"{versus.ToString().PadLeft(1).PadRight(1)} | " +
                        $"{entrada.TimeB.PadRight(14).PadLeft(18)} | " +
                        $"{entrada.Liga.PadRight(12).PadLeft(14)} | " +
                        $"{entrada.Mercado.PadRight(10).PadLeft(13)} | " +
                        $"{entrada.Status.ToString().PadRight(7).PadLeft(8)} |");

                    Console.WriteLine("----|------------|-------|---------|--------------|----------|---------------|--------------------|---|--------------------|----------------|---------------|----------|");
                    index++;
                }
            }
        }
        public static void ExibirApostasFinalizadasFiltradaLiga(string liga)
        {
            Bankroll bank = new Bankroll();
            List<Entrada> jogosFiltrados = LinqFilter.FiltrarLiga(ApostasFinalizadas.entradasFinalizadas, liga);

            if (jogosFiltrados.Count == 0)
            {
                Console.WriteLine("Nenhum jogo encontrado para esse time específico");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Esses são todos os jogos da liga: {liga}");
                Console.WriteLine(" Nº |    Data    |  Odd  |  Stake  |     Saldo    | PL/Banca |    PL/Stake   |       Time A       | x |       Time B       |      Liga      |    Mercado    |  Status  |");
                Console.WriteLine("----|------------|-------|---------|--------------|----------|---------------|--------------------|---|--------------------|----------------|---------------|----------|");

                int index = 1;
                foreach (Entrada jogo in jogosFiltrados)
                {
                    Entrada entrada = jogo;
                    double plBank = bank.PL_Lucro(entrada.Saldo) * 100;
                    double plStake = bank.PL_Stake(entrada.Saldo, entrada.Stake) * 100;
                    string plBankPorcentagem = plBank.ToString("N2") + "%";
                    string plStakePorcentagem = plStake.ToString("N2") + "%";

                    string versus = "x";

                    Console.WriteLine($" {index}  | " +
                        $"{entrada.Data} | " +
                        $"{entrada.Odd.ToString().PadRight(3).PadLeft(5)} | " +
                        $"{entrada.Stake.ToString("C", CultureInfo.GetCultureInfo("en-GB"))} | " +
                        $"{entrada.Saldo.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                        $"{plBankPorcentagem.PadRight(7).PadLeft(8)} | " +
                        $"{plStakePorcentagem.PadRight(11).PadLeft(13)} | " +
                        $"{entrada.TimeA.PadRight(14).PadLeft(18)} | " +
                        $"{versus.ToString().PadLeft(1).PadRight(1)} | " +
                        $"{entrada.TimeB.PadRight(14).PadLeft(18)} | " +
                        $"{entrada.Liga.PadRight(12).PadLeft(14)} | " +
                        $"{entrada.Mercado.PadRight(10).PadLeft(13)} | " +
                        $"{entrada.Status.ToString().PadRight(7).PadLeft(8)} |");

                    Console.WriteLine("----|------------|-------|---------|--------------|----------|---------------|--------------------|---|--------------------|----------------|---------------|----------|");
                    index++;
                }
            }
        }
        public static void ExibirApostasFinalizadasFiltradaMercado(string mercado)
        {
            Bankroll bank = new Bankroll();
            List<Entrada> jogosFiltrados = LinqFilter.FiltrarMercado(ApostasFinalizadas.entradasFinalizadas, mercado);

            if (jogosFiltrados.Count == 0)
            {
                Console.WriteLine("Nenhum jogo encontrado para esse time específico");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Esses são todos os jogos do mercado: {mercado}");
                Console.WriteLine(" Nº |    Data    |  Odd  |  Stake  |     Saldo    | PL/Banca |    PL/Stake   |       Time A       | x |       Time B       |      Liga      |    Mercado    |  Status  |");
                Console.WriteLine("----|------------|-------|---------|--------------|----------|---------------|--------------------|---|--------------------|----------------|---------------|----------|");

                int index = 1;
                foreach (Entrada jogo in jogosFiltrados)
                {
                    Entrada entrada = jogo;
                    double plBank = bank.PL_Lucro(entrada.Saldo) * 100;
                    double plStake = bank.PL_Stake(entrada.Saldo, entrada.Stake) * 100;
                    string plBankPorcentagem = plBank.ToString("N2") + "%";
                    string plStakePorcentagem = plStake.ToString("N2") + "%";

                    string versus = "x";

                    Console.WriteLine($" {index}  | " +
                        $"{entrada.Data} | " +
                        $"{entrada.Odd.ToString().PadRight(3).PadLeft(5)} | " +
                        $"{entrada.Stake.ToString("C", CultureInfo.GetCultureInfo("en-GB"))} | " +
                        $"{entrada.Saldo.ToString("C", CultureInfo.GetCultureInfo("en-GB")).PadRight(10).PadLeft(12)} | " +
                        $"{plBankPorcentagem.PadRight(7).PadLeft(8)} | " +
                        $"{plStakePorcentagem.PadRight(11).PadLeft(13)} | " +
                        $"{entrada.TimeA.PadRight(14).PadLeft(18)} | " +
                        $"{versus.ToString().PadLeft(1).PadRight(1)} | " +
                        $"{entrada.TimeB.PadRight(14).PadLeft(18)} | " +
                        $"{entrada.Liga.PadRight(12).PadLeft(14)} | " +
                        $"{entrada.Mercado.PadRight(10).PadLeft(13)} | " +
                        $"{entrada.Status.ToString().PadRight(7).PadLeft(8)} |");

                    Console.WriteLine("----|------------|-------|---------|--------------|----------|---------------|--------------------|---|--------------------|----------------|---------------|----------|");
                    index++;
                }
            }
        }
    }
}
