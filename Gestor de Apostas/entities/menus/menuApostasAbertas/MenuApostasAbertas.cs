using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.entrada;

namespace Gestor_de_Apostas.entities.menus.menuApostasAbertas
{
    internal class MenuApostasAbertas : Menus
    {
        ApostasAbertas apostasAbertas = new();
        ApostasFinalizadas apostasFinalizadas = new();
        public override void ExecutarMenu()
        {

            base.ExecutarMenu();
            apostasAbertas.ExibirApostasAbertas();
            ExibirMenu();

            Console.Write("\nSeleciona o indice desejado: ");

            Dictionary<int, Action> opcoes = new()
                {
                    { 1, FinalizarEntrada },
                    { 2, EditarEntrada },
                    { 3, VoltarAoInicio }
                };

            string opcao = Console.ReadLine()!;
            int opcaoEscolhida = int.Parse(opcao);
            Action menu = opcoes[opcaoEscolhida];

            if (opcoes.ContainsKey(opcaoEscolhida))
            {
                Action menuASerExibido = opcoes[opcaoEscolhida];
                menuASerExibido();
            }
            else
            {
                Console.WriteLine("\nValor digitado inválido. Por favor, tente novamente.");
                Console.WriteLine("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                ExecutarMenu();
            }
        }

        public void ExibirMenu()
        {
            Console.WriteLine("\n1. Finalizar uma entrada");
            Console.WriteLine("2. Editar uma entrada");
            Console.WriteLine("3. Voltar ao início");
        }
        public void FinalizarEntrada()
        {
            Console.Write("\nSeleciona a aposta que você deseja: ");

            int numeroFinalizar = int.Parse(Console.ReadLine()!);
            Entrada itemRemovido = ApostasAbertas.entradasAbertas[numeroFinalizar - 1];
            apostasAbertas.FinalizarApostaAberta(itemRemovido);
            apostasFinalizadas.AdicionarApostaFinalizadas(itemRemovido);
            apostasAbertas.RemoverApostaAbertas(itemRemovido);
            ExecutarMenu();
        }
        public void EditarEntrada()
        {
            MenuEditarEntrada menu = new();
            menu.ExecutarMenu();
        }
    }
}
