namespace Gestor_de_Apostas.entities.menus
{
    internal class MenuSair : Menus
    {
        public override void ExecutarMenu()
        {
            base.ExecutarMenu();
            Console.WriteLine("Pressione qualquer tecla para fechar o programa.");
            Console.WriteLine("Tchau Tchau!!  ;) ");
            Console.ReadKey();
            Environment.Exit(0);

        }
    }
}
