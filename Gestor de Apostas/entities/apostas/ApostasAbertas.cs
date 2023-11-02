using Gestor_de_Apostas.entities.entrada;
using Gestor_de_Apostas.entities.especificos;
using System.Globalization;

namespace Gestor_de_Apostas.entities.apostas
{
    internal class ApostasAbertas
    {
        public static List<Entrada> entradasAbertas { get; } = new List<Entrada>();
        public void FinalizarApostaAberta(Entrada entrada)
        {

            Bankroll bank = new();
            Equipes equipes = new();
            ApostaGeral aposta = new();

            Console.WriteLine(" Atualize aqui o status da aposta(Certa ou Errada): ");
            string resposta = Console.ReadLine().ToLower();
            if (resposta == "certo" || resposta == "certa" || resposta == "c")
            {
                Console.Clear();
                entrada.Status = StatusAposta.Certa;
                entrada.Saldo = bank.Lucro(entrada.Status, entrada.Stake, entrada.Odd);

                Console.WriteLine();
                equipes.AdicicionarTime(entrada);
                aposta.ExibirApostaSelecionada(entrada);

                Console.WriteLine("\n Aperte qualquer tecla para continuar");
                Console.ReadKey();

            }
            else if (resposta == "errado" || resposta == "errada" || resposta == "e")
            {
                Console.Clear();
                entrada.Status = StatusAposta.Errada;
                entrada.Saldo = bank.Lucro(entrada.Status, entrada.Stake, entrada.Odd);

                Console.WriteLine();
                equipes.AdicicionarTime(entrada);
                aposta.ExibirApostaSelecionada(entrada);

                Console.WriteLine("\n Aperte qualquer tecla para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(" Valor inserido inválido, tente novamente!");
                Console.WriteLine(" Aperte qualquer tecla para continuar");
                Console.ReadKey();
                FinalizarApostaAberta(entrada);
            }

            Console.WriteLine(" Aposta finalizada com sucesso!!");

        }
        public void AdicionarApostaAbertas(Entrada entrada)
        {
            entradasAbertas.Add(entrada);

        }
        public void RemoverApostaAbertas(Entrada entrada)
        {
            entradasAbertas.Remove(entrada);

        }
        public void ExibirApostasAbertas()
        {

            Console.WriteLine(" Nº |    Data    |  Odd  |  Stake  |       Time A       | x |       Time B       |      Liga      |    Mercado    |   Status   |");
            Console.WriteLine("----|------------|-------|---------|--------------------|---|--------------------|----------------|---------------|------------|");

            int index = 1;
            foreach (Entrada novaentrada in entradasAbertas)
            {
                string versus = "x";

                Console.WriteLine($" {index}  | " +
                    $"{novaentrada.Data} | " +
                    $"{novaentrada.Odd.ToString().PadRight(4),5} | " +
                    $"{novaentrada.Stake.ToString("C", CultureInfo.GetCultureInfo("en-GB"))} | " +
                    $"{novaentrada.TimeA.PadRight(14),18} | " +
                    $"{versus.ToString().PadRight(1),1} | " +
                    $"{novaentrada.TimeB.PadRight(14),18} | " +
                    $"{novaentrada.Liga.PadRight(12),14} | " +
                    $"{novaentrada.Mercado.PadRight(10),13} | " +
                    $"{novaentrada.Status.ToString().PadRight(9),10} |");

                Console.WriteLine("----|------------|-------|---------|--------------------|---|--------------------|----------------|---------------|------------|");

            }
        }
    }
}
