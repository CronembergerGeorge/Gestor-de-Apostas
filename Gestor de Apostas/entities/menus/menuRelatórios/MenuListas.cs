using Gestor_de_Apostas.entities.especificos;

namespace Gestor_de_Apostas.entities.menus.menuRelatórios
{
    internal class MenuListas : Menus
    {
        public override void ExecutarMenu()
        {
            base.ExecutarMenu();

            Console.WriteLine("1. Lista por Time");
            Console.WriteLine("2. Lista por Liga");
            Console.WriteLine("3. Lista por Mercado");
            Console.WriteLine("-1. Volte ao início");

            Console.Write("Digite o numero do índice desejado para continuar: ");
            int indice = int.Parse(Console.ReadLine());
            

            if (indice >= 1 && indice <= 3 || indice == -1)
            {
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

        public void MostrarListaEspecifica(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    Equipes equipe = new();
                    equipe.ExibirListaTime(Equipes.listaTimes);
                    break;
                case 2:
                    Ligas liga = new();
                    liga.ExibirListaLiga();
                    break;
                case 3:
                    Mercados mercado = new();
                    mercado.ExibirListaMercado();
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
