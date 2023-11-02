using Gestor_de_Apostas.entities.entrada;


namespace Gestor_de_Apostas.entities.ordenarFiltrar
{
    internal class LinqFilter
    {
        public static List<Entrada> FiltrarTime(List<Entrada> lista, string nomeTime)
        {
            return lista.Where(entrada => entrada.TimeA.Contains(nomeTime) ||
                               entrada.TimeB.Contains(nomeTime))
                               .ToList();
        }
        public static List<Entrada> FiltrarLiga(List<Entrada> lista, string liga)
        {
            return lista.Where(entrada => entrada.Liga.Contains(liga)).ToList();
        }
        public static List<Entrada> FiltrarMercado(List<Entrada> lista, string mercado)
        {
            return lista.Where(entrada => entrada.Mercado.Contains(mercado)).ToList();

        }
    }
}
