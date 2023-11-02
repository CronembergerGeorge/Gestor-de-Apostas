using Gestor_de_Apostas.entities.entrada;
using Gestor_de_Apostas.entities.especificos;
using System.Globalization;

namespace Gestor_de_Apostas.entities.apostas
{
    internal class ApostaGeral : Entrada
    {
        public void AdicionarEntradas()
        {
            Bankroll bank = new();


            ApostasAbertas.entradasAbertas.Add(new Entrada(DateOnly.Parse("2022-05-10"), 1.85, 100.0, 0, "Flamengo", "Palmeiras", "Brasileirão", "Resultado", StatusAposta.EmAberta));
            ApostasAbertas.entradasAbertas.Add(new Entrada(DateOnly.Parse("2022-06-10"), 2.1, 150.0, 0, "Barcelona", "Real Madrid", "La Liga", "Resultado", StatusAposta.EmAberta));
            ApostasAbertas.entradasAbertas.Add(new Entrada(DateOnly.Parse("2022-07-10"), 1.5, 200.0, 0, "Bayern", "Borussia Dortmund", "Bundesliga", "Resultado", StatusAposta.EmAberta));

            ApostasFinalizadas.entradasFinalizadas.Add(new Entrada(DateOnly.Parse("2022-05-10"), 2.0, 100.0, bank.Lucro(StatusAposta.Errada, 100, 2.0), "Vasco", "Bahia", "Brasileirão", "Resultado", StatusAposta.Errada));
            ApostasFinalizadas.entradasFinalizadas.Add(new Entrada(DateOnly.Parse("2020-05-10"), 2.0, 100.0, bank.Lucro(StatusAposta.Certa, 100, 2.0), "Bahia", "Vasco", "Brasileirão", "Resultado", StatusAposta.Certa));
            ApostasFinalizadas.entradasFinalizadas.Add(new Entrada(DateOnly.Parse("2022-06-10"), 2.0, 100.0, bank.Lucro(StatusAposta.Certa, 100, 2.0), "Villarreal", "Real Madrid", "La Liga", "Resultado", StatusAposta.Certa));
            ApostasFinalizadas.entradasFinalizadas.Add(new Entrada(DateOnly.Parse("2022-04-10"), 2.0, 100.0, bank.Lucro(StatusAposta.Certa, 100, 2.0), "Villarreal", "Mainz", "La Liga", "Resultado", StatusAposta.Certa));
            ApostasFinalizadas.entradasFinalizadas.Add(new Entrada(DateOnly.Parse("2021-07-10"), 2.15, 100.0, bank.Lucro(StatusAposta.Errada, 100, 2.15), "Leipzig", "Mainz", "Bundesliga", "Over 1,5", StatusAposta.Errada));

            AdicionarTimeLigaMercadoAuxiliar(ApostasFinalizadas.entradasFinalizadas);
        }

        public void ExibirApostaSelecionada(Entrada entrada)
        {
            Console.WriteLine($"  {entrada.Data} | {entrada.Odd} | {entrada.Stake.ToString("C", CultureInfo.GetCultureInfo("en-GB"))} | {entrada.TimeA} |  x  | {entrada.TimeB} | {entrada.Liga} | {entrada.Mercado} | {entrada.Status} |");
        }

        //Função apenas para visualização

        public void AdicionarTimeLigaMercadoAuxiliar(List<Entrada> entradasFinalizadas)
        {

            foreach (Entrada entrada in entradasFinalizadas)
            {
                string equipe1 = entrada.TimeA!;
                string equipe2 = entrada.TimeB!;

                if (!Equipes.listaTimes.Contains(equipe1))
                {
                    Equipes.listaTimes.Add(equipe1);

                }
                if (!Equipes.listaTimes.Contains(equipe2))
                {
                    Equipes.listaTimes.Add(equipe2);

                }

                string liga = entrada.Liga!;
                if (!Ligas.listaLigas.Contains(liga))
                {
                    Ligas.listaLigas.Add(liga);
                }
                string mercado = entrada.Mercado!;
                if (!Mercados.listaMercado.Contains(mercado))
                {
                    Mercados.listaMercado.Add(mercado);
                }
            }
        }
    }
}
