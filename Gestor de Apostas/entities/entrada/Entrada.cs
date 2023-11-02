using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.especificos;
using Gestor_de_Apostas.entities.menus;
using System.Globalization;

namespace Gestor_de_Apostas.entities.entrada
{
    internal class Entrada
    {
        public DateOnly Data { get; set; }
        public double Odd { get; set; }
        public double Stake { get; set; }
        public string? TimeA { get; set; }
        public string? TimeB { get; set; }
        public string? Liga { get; set; }
        public string? Mercado { get; set; }
        public double Saldo { get; set; }

        public StatusAposta Status { get; set; }

        public Entrada()
        {

        }

        public Entrada(DateOnly data, double odd, double stake, double saldo, string timeA, string timeB, string liga, string mercado, StatusAposta status)
        {
            Data = data;
            Odd = odd;
            Stake = stake;
            Saldo = saldo;
            TimeA = timeA;
            TimeB = timeB;
            Liga = liga;
            Mercado = mercado;
            Status = status;
        }

        public void Dados()
        {
            Bankroll bank = new Bankroll();
            Equipes equipes = new Equipes();
            ApostasAbertas apostaAberta = new ApostasAbertas();
            Menus menu = new Menus();

            Console.Clear();
            try
            {
                DateOnly data = ValidarData("Digite a Data(DD/MM/AAAA): ");
                double odd = ValidarDouble("Digite o valor da Odd: ");
                double stake = ValidarDouble("Digite o valor da Stake: ");
                string timeA = ValidarString("Digite o nome do time da casa: ");
                string timeB = ValidarString("Digite o nome do time Visitante: ");
                string liga = ValidarString("Digite o nome da Liga: ");
                string mercado = ValidarString("Digite o nome do Mercado: ");
                Console.Write("\n");
                StatusAposta status = StatusAposta.EmAberta;
                double saldo = bank.Lucro(status, stake, odd);

                Entrada entrada = new Entrada(data, odd, stake, saldo, timeA, timeB, liga, mercado, status);
                apostaAberta.AdicionarApostaAbertas(entrada);
                equipes.AdicicionarTime(entrada);
            }
            catch (Exception e)

            {
                Console.WriteLine($"Erro: {e.Message}");
            }

            menu.VoltarAoInicio();

        }
        private static DateOnly ValidarData(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine()!;
                if (DateOnly.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date))
                {
                    return date;
                }
                Console.Clear();
                Console.WriteLine("Data inválida. Tente novamente.");
            }
        }
        private static double ValidarDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double d))
                {
                    return d;
                }
                Console.Clear();
                Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }
        public static string ValidarString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(input))
                {
                    bool numerico = double.TryParse(input, out double d);
                    if (!numerico)
                    {
                        return input;
                    }
                }
                Console.Clear();
                Console.WriteLine("Valor inválido. Tente novamente");
            }
        }
    }
}
