using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.entrada;
using Gestor_de_Apostas.entities.ordenarFiltrar;


namespace Gestor_de_Apostas.entities.menus.menuRelatórios
{
    internal class MenuApostasFinalizadas : Menus
    {
        Entrada entrada = new();
        public override void ExecutarMenu()
        {
            base.ExecutarMenu();
            ApostasFinalizadas.ExibirApostasFinalizadas();
            Console.WriteLine();
            Console.WriteLine("1. Filtrar por Equipe");
            Console.WriteLine("2. Filtrar por Liga");
            Console.WriteLine("3. Filtrar por Mercado");
            Console.WriteLine("-1. Voltar ao menu inicial");

            Console.Write("Digite o numero do índice desejado para continuar: ");
            string input = Console.ReadLine()!;

            if(int.TryParse(input, out int indice))
            {
                if ((indice >= 1 && indice <= 3) || indice == -1)
                {
                    Console.Clear();
                    MostrarListaEspecifica(indice);
                    Console.WriteLine("\nPressione qualquer tecla para voltar.");
                    Console.ReadKey();
                    ExecutarMenu();
                }
                else
                {
                    Console.WriteLine("\nOpção inválida. Tente novamente.");
                    ExecutarMenu();
                }
            }
            
        }
        public void MostrarListaEspecifica(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    string time = Entrada.ValidarString("Digite o nome do time desejado: ");
                    LinqExibir.ExibirApostasFinalizadasFiltradaTime(time);
                    break;
                case 2:
                    string liga = Entrada.ValidarString("Digite o nome da liga desejada: ");
                    LinqExibir.ExibirApostasFinalizadasFiltradaLiga(liga);
                    break;
                case 3:
                    string mercado = Entrada.ValidarString("Digite o nome do mercado desejado: ");
                    LinqExibir.ExibirApostasFinalizadasFiltradaMercado(mercado);
                    break;
                case -1:
                    VoltarAoInicio();
                    break;
                default:
                    Console.WriteLine("Valor digitado inválido. Por favor, tente novamente.");
                    break;

            }
        }
    }
}
