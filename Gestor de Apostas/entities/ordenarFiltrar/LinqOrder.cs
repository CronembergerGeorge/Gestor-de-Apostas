

using Gestor_de_Apostas.entities.entrada;

namespace Gestor_de_Apostas.entities.ordenarFiltrar
{
    internal class LinqOrder
    {
        public static List<Entrada> OrdenarData(List<Entrada> lista)
        {
            return lista.OrderByDescending(item => item.Data).ToList();
        }
        public static List<string> OrdenarTime(List<string> lista)
        {
            return lista.OrderBy(item => item).ToList();
        }
        public static List<string> OrdenarLiga(List<string> lista)
        {
            return lista.OrderBy(item => item).ToList();
        }
        public static List<string> OrdenarMercado(List<string> lista)
        {
            return lista.OrderBy(item => item).ToList();
        }

    }
}
