using Gestor_de_Apostas.entities.apostas;
using Gestor_de_Apostas.entities.entrada;

namespace Gestor_de_Apostas.entities
{
    internal class Bankroll
    {
        public double BancaInicial { get; set; } = 5000;
        public double BancaFinal { get; set; }


        public Bankroll()
        {
        }

        public Bankroll(double bancainicial)
        {
            BancaInicial = bancainicial;
        }

        public Bankroll(double bancafinal, double bancainicial)
        {
            BancaFinal = bancafinal;
            BancaInicial = bancainicial;
        }

        public double Lucro(StatusAposta status, double stake, double odd)
        {
            double lucro;
            if (status == StatusAposta.EmAberta)
            {
                lucro = 0;
            }
            else if (status == StatusAposta.Certa)
            {
                lucro = stake * odd - stake;
            }
            else if (status == StatusAposta.Errada)
            {
                lucro = -stake;
            }
            else
            {
                lucro = 0;
            }

            return lucro;
        }

        public double AtualizarBanca(List<Entrada> entradasFinalizadas)
        {
            double SomaTotal = 0;
            foreach (Entrada entrada in entradasFinalizadas)
            {
                double lucro = Lucro(entrada.Status, entrada.Stake, entrada.Odd);
                SomaTotal += lucro;
            }
            return BancaFinal = BancaInicial + SomaTotal;
        }

        public double PL_Lucro(double lucro)
        {
            double resultado = lucro / BancaInicial;
            return resultado;
        }

        public double PL_Banca(double bancafinal)
        {
            double resultado = bancafinal - BancaInicial;
            return resultado;
        }

        public double PL_Stake(double lucro, double stake)
        {
            double resultado = lucro / stake;
            return resultado;
        }

        public double Soma_Stake(List<Entrada> entradasFinalizadas)
        {
            double soma = 0;

            foreach (Entrada entrada in entradasFinalizadas)
            {
                double stake = entrada.Stake;
                soma += stake;
            }
            return soma;
        }

        public double Cont_Stake_Media(List<Entrada> entradasFinalizadas)
        {
            double soma = 0;
            int cont = 0;
            foreach (Entrada entrada in entradasFinalizadas)
            {
                double stake = entrada.Stake;
                soma += stake;
                cont++;
            }
            return soma / cont;
        }

        public double Cont_Certas(List<Entrada> entradasFinalizadas, StatusAposta status)
        {
            int cont = 0;

            foreach (Entrada entrada in entradasFinalizadas)
            {
                if (entrada.Status == StatusAposta.Certa)
                    cont++;
            }
            return cont;
        }

        public double Cont_Erradas(List<Entrada> entradasFinalizadas, StatusAposta status)
        {
            int cont = 0;

            foreach (Entrada entrada in entradasFinalizadas)
            {
                if (entrada.Status == StatusAposta.Errada)
                    cont++;
            }
            return cont;
        }


    }
}
