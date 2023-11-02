using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.entrada;

namespace Gestor_de_Apostas.entities.menus.menuApostasAbertas
{
    internal class MenuEditarEntrada : Menus
    {
        ApostaGeral apostaGeral = new();
        public override void ExecutarMenu()
        {
            base.ExecutarMenu();

            ApostasAbertas aposta = new();
            aposta.ExibirApostasAbertas();

            Console.Write("\nSeleciona a aposta que você deseja editar: ");
            int numeroEditar = int.Parse(Console.ReadLine());

            ExibirMenu(numeroEditar);

            Console.WriteLine();
            Console.WriteLine("O que você deseja editar? ");

            Entrada visualizaentrada = ApostasAbertas.entradasAbertas[numeroEditar - 1];
            Console.WriteLine();
            apostaGeral.ExibirApostaSelecionada(visualizaentrada);

        }

        public void ExibirMenu(int numero)
        {
            Entrada entradaSelecionada = ApostasAbertas.entradasAbertas[numero - 1];

            Console.WriteLine("1. Data");
            Console.WriteLine("2. Odd");
            Console.WriteLine("3. Stake");
            Console.WriteLine("4. Time A");
            Console.WriteLine("5. Time B");
            Console.WriteLine("6. Liga");
            Console.WriteLine("7. Mercado");
            Console.WriteLine("8. Voltar ao menu anterior");
            Console.WriteLine("9. Voltar ao menu principal");

            Console.Write("\nDigite o número do item que deseja editar: ");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao >= 1 && opcao <= 7)
            {
                Console.Write("Digite o novo valor para o item: ");
                string novoValor = Console.ReadLine();

                // Atualizando os valores corretamente
                AtualizarPropriedade(entradaSelecionada, opcao, novoValor);

                Console.Clear();
                Console.WriteLine($"\nItem {opcao} atualizado com sucesso!");
                apostaGeral.ExibirApostaSelecionada(entradaSelecionada);
                ExibirMenu(numero); // Exibe o menu novamente com a entrada selecionada
            }
            else if (opcao == 8)
            {
                // Volta ao menu anterior
                MenuApostasAbertas menu = new MenuApostasAbertas();
                menu.ExecutarMenu();
            }
            else if (opcao == 9)
            {
                // Volta ao menu principal
                MenuPrincipal menu = new MenuPrincipal();
                menu.ExecutarMenu();
            }
            else
            {
                Console.WriteLine("\nOpção inválida. Tente novamente.");
                ExibirMenu(numero);
            }
        }

        private void AtualizarPropriedade(Entrada entrada, int opcao, string novoValor)
        {
            switch (opcao)
            {
                case 1:
                    entrada.Data = DateOnly.Parse(novoValor);
                    break;
                case 2:
                    entrada.Odd = double.Parse(novoValor);
                    break;
                case 3:
                    entrada.Stake = double.Parse(novoValor);
                    break;
                case 4:
                    entrada.TimeA = novoValor;
                    break;
                case 5:
                    entrada.TimeB = novoValor;
                    break;
                case 6:
                    entrada.Liga = novoValor;
                    break;
                case 7:
                    entrada.Mercado = novoValor;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
