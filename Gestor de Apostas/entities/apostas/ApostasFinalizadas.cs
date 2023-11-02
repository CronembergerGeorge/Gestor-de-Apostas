using Gestor_de_Apostas.entities.entrada;
using Gestor_de_Apostas.entities.ordenarFiltrar;
using System.Globalization;

namespace Gestor_de_Apostas.entities.apostas
{
    internal class ApostasFinalizadas : Entrada
    {
        public static List<Entrada> entradasFinalizadas { get; set; } = new List<Entrada>();

        public void AdicionarApostaFinalizadas(Entrada entrada)
        {
            entradasFinalizadas.Add(entrada);
        }

        public void RemoverApostaFinalizadas(Entrada entrada)
        {
            entradasFinalizadas.Remove(entrada);

        }

        public static void ExibirApostasFinalizadas()
        {
            Bankroll bank = new Bankroll();

            Console.WriteLine(" Nº |    Data    |  Odd  |  Stake  |     Saldo    | PL/Banca |    PL/Stake   |       Time A       | x |       Time B       |      Liga      |    Mercado    |  Status  |");
            Console.WriteLine("----|------------|-------|---------|--------------|----------|---------------|--------------------|---|--------------------|----------------|---------------|----------|");

            entradasFinalizadas = LinqOrder.OrdenarData(entradasFinalizadas);
            int index = 1;
            foreach (Entrada entrada in entradasFinalizadas)
            {
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
                    $"{entrada.TimeA?.PadRight(14).PadLeft(18)} | " +
                    $"{versus.ToString().PadLeft(1).PadRight(1)} | " +
                    $"{entrada.TimeB?.PadRight(14).PadLeft(18)} | " +
                    $"{entrada.Liga?.PadRight(12).PadLeft(14)} | " +
                    $"{entrada.Mercado?.PadRight(10).PadLeft(13)} | " +
                    $"{entrada.Status.ToString().PadRight(7).PadLeft(8)} |");

                Console.WriteLine("----|------------|-------|---------|--------------|----------|---------------|--------------------|---|--------------------|----------------|---------------|----------|");
                index++;
            }
        }
    }
}
