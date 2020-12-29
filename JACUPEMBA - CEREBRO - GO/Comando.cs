using Accord.Neuro;
using Accord.Neuro.Learning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JACUPEMBA___CEREBRO___GO
{
    public static class Comando
    {
        static Rede_Neural.RedeNeural nn = null;
        //static ActivationNetwork nn = null;
        //static LevenbergMarquardtLearning teacher = null;

        public static void CriarRedeNeural(int[] Topologia)
        {

        }

        //Funcionou com a minha Rede Neural
        public static void Estudar(decimal[] Entradas, decimal[] Saida)
        {
            if (nn == null)
                nn = new Rede_Neural.RedeNeural(4, 4, 1);

            nn.Treinar(Entradas, Saida);
        }

        public static decimal[] Previsao(decimal[] Entradas)
        {
            return nn.Previsao(Entradas);
        }
        //public static void Estudar(double[] Entradas, double[] Saida)
        //{
        //    if (nn == null)
        //    {
        //        nn = new ActivationNetwork(new SigmoidFunction(), 4, 4, 1);
        //        teacher = new LevenbergMarquardtLearning(nn, false, JacobianMethod.ByBackpropagation);
        //    }

        //    teacher.RunEpoch(new double[][] { Entradas }, new double[][] { Saida });
        //}

        //public static double[] Previsao(double[] Entradas)
        //{
        //    return nn.Compute(Entradas);
        //}
    }
}
