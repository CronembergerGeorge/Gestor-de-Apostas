using Gestor_de_Apostas.entities.menus.menuApostasAbertas;
using Gestor_de_Apostas.entities.menus.menuRelatórios;


namespace Gestor_de_Apostas.entities.menus
{
    internal class MenuPrincipal : Menus
    {
        public override void ExecutarMenu()
        {
            base.ExecutarMenu();
            Console.WriteLine("1. Verificar progresso atual");
            Console.WriteLine("2. Criar Aposta");
            Console.WriteLine("3. Apostas Abertas");
            Console.WriteLine("4. Apostas Finalizadas");
            Console.WriteLine("5. Relatórios");
            Console.WriteLine("-1. Sair");

            Console.WriteLine();
            Console.Write("Digite o numero do índice desejado para continuar: ");

            try
            {
                Dictionary<int, Menus> opcoes = new()
                {
                    { 1, new MenuProgresso() },
                    { 2, new MenuCriar() },
                    { 3, new MenuApostasAbertas() },
                    { 4, new MenuApostasFinalizadas() },
                    { 5, new MenuListas() },
                    { -1, new MenuSair() }
                };

                string opcao = Console.ReadLine()!;
                int opcaoEscolhida = int.Parse(opcao);
                Menus menu = opcoes[opcaoEscolhida];

                if (opcoes.ContainsKey(opcaoEscolhida))
                {
                    Menus menuASerExibido = opcoes[opcaoEscolhida];
                    menuASerExibido.ExecutarMenu();
                }
                else
                {
                    Console.WriteLine("\nValor digitado inválido. Por favor, tente novamente.");
                    Console.WriteLine("Pressione qualquer tecla para voltar.");
                    Console.ReadKey();
                    ExecutarMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
                Console.WriteLine("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                ExecutarMenu();
            }
        }
    }
}
