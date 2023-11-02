using Gestor_de_Apostas.entities.apostas;
using System.Globalization;

namespace Gestor_de_Apostas.entities.menus
{
    internal class MenuProgresso : Menus
    {
        public override void ExecutarMenu()
        {
            base.ExecutarMenu();
            ExibirMenuProgresso();
            Console.ReadKey();
            VoltarAoInicio();
        }
        public void ExibirMenuProgresso()
        {

            Bankroll bank = new();

            double entradasCertas = bank.Cont_Certas(ApostasFinalizadas.entradasFinalizadas, StatusAposta.Certa);
            double entradasErradas = bank.Cont_Erradas(ApostasFinalizadas.entradasFinalizadas, StatusAposta.Errada);
            double bancaInicial = bank.BancaInicial;
            double bancaatual = bank.AtualizarBanca(ApostasFinalizadas.entradasFinalizadas);

            double lucro = bank.PL_Banca(bancaatual);
            double lucroBanca = lucro / bancaInicial * 100;

            double entradastotais = entradasCertas + entradasErradas;
            double winRate = entradasCertas / entradastotais * 100;

            double mediaStake = bank.Cont_Stake_Media(ApostasFinalizadas.entradasFinalizadas);
            double plStake = lucro / mediaStake * 100;

            double somaStake = bank.Soma_Stake(ApostasFinalizadas.entradasFinalizadas);
            double yield = lucro / somaStake * 100;

            Console.WriteLine($"A sua Banca incial era: {bancaInicial.ToString("C", CultureInfo.GetCultureInfo("en-GB"))}");
            Console.WriteLine($"A sua Banca atual é : {bancaatual.ToString("C", CultureInfo.GetCultureInfo("en-GB"))}");

            Console.WriteLine($"\nTotal de entradas: {entradastotais}");
            Console.WriteLine($"Você acertou : {entradasCertas}");
            Console.WriteLine($"Você errou: {entradasErradas} ");
            Console.WriteLine($"WinRate: {winRate.ToString("N2")}%");

            Console.WriteLine($"Yield: {yield.ToString("N2")}%");
            Console.WriteLine($"PL/Banca(£): {lucro.ToString("C", CultureInfo.GetCultureInfo("en-GB"))}");
            Console.WriteLine($"Pl/Banca: {lucroBanca.ToString("N2")}%");
            Console.WriteLine($"PL/Stake: {plStake.ToString("N2")}%");
            Console.WriteLine();

        }
    }
}
