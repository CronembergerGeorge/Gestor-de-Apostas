namespace Gestor_de_Apostas.entities.menus
{
    class Menus
    {
        public virtual void ExecutarMenu()
        {
            Console.Clear();
        }
        public void VoltarAoInicio()
        {
            while (Console.KeyAvailable)
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");

                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter || key == ConsoleKey.Escape)
                    return; // Retornar ao menu principal
            }
            new MenuPrincipal().ExecutarMenu();
        }
    }
}
