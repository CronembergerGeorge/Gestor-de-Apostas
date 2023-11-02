using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.menus;

namespace Gestor_de_Apostas.entities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApostaGeral aposta = new();
            MenuPrincipal principal = new();

            aposta.AdicionarEntradas();
            principal.ExecutarMenu();

        }

    }
}
