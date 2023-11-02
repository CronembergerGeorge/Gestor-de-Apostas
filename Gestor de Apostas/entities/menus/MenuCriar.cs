using Gestor_de_Apostas.entities.entrada;

namespace Gestor_de_Apostas.entities.menus
{
    internal class MenuCriar : Menus
    {
        public override void ExecutarMenu()
        {
            base.ExecutarMenu();

            Entrada entrada = new();
            entrada.Dados();
            VoltarAoInicio();
        }
    }
}
