using System;

namespace Rede_Neural
{
    public class Matriz
    {
        public int Linhas { get; private set; }
        public int Colunas { get; private set; }
        public decimal[,] Dados { get; set; }
        public Matriz(decimal[] array)
        {
            this.Dados = new decimal[array.Length, 1];
            this.Linhas = array.Length;
            this.Colunas = 1;

            Map((valor, linha, coluna) =>
            {
                return array[linha];
            });
        }
        public Matriz(int Linhas, int Colunas)
        {
            this.Dados = new decimal[Linhas, Colunas];
            this.Linhas = Linhas;
            this.Colunas = Colunas;

            for (int i = 0; i < Linhas; i++)
            {
                for (int j = 0; j < Colunas; j++)
                {
                    this.Dados[i, j] = Util.RandomNumero(); //Util.RandomNumero(0, 10);
                }
            }
        }
        public void Map(Func<decimal, int, int, decimal> action)
        {
            for (int i = 0; i < this.Dados.GetLength(0); i++)
                for (int j = 0; j < this.Dados.GetLength(1); j++)
                    this.Dados[i, j] = action(this.Dados[i, j], i, j);
        }
        public static Matriz operator +(Matriz c1, Matriz c2)
        {
            Matriz Resultado = new Matriz(c1.Linhas, c1.Colunas);

            Resultado.Map((valor, linha, coluna) =>
            {
                return c1.Dados[linha, coluna] + c2.Dados[linha, coluna];
            });

            return Resultado;
        }
        public static Matriz operator -(Matriz c1, Matriz c2)
        {
            Matriz Resultado = new Matriz(c1.Linhas, c1.Colunas);

            Resultado.Map((valor, linha, coluna) =>
            {
                return c1.Dados[linha, coluna] - c2.Dados[linha, coluna];
            });

            return Resultado;
        }
        public static Matriz operator *(Matriz c1, Matriz c2)
        {
            Matriz Resultado = new Matriz(c1.Linhas, c2.Colunas);

            Resultado.Map((valor, linha, coluna) =>
            {
                decimal operacao = 0;
                for (int i = 0; i < c1.Colunas; i++)
                {
                    decimal Valor1 = c1.Dados[linha, i];
                    decimal Valor2 = c2.Dados[i, coluna];
                    operacao += Valor1 * Valor2;
                }
                return operacao;
            });

            return Resultado;
        }
        public static Matriz operator *(Matriz c1, decimal escalar)
        {
            Matriz Resultado = new Matriz(c1.Linhas, c1.Colunas);

            Resultado.Map((valor, linha, coluna) =>
            {
                return c1.Dados[linha, coluna] * escalar;
            });

            return Resultado;
        }
        public static Matriz operator !(Matriz c1)
        {
            Matriz Resultado = new Matriz(c1.Colunas, c1.Linhas);

            Resultado.Map((valor, linha, coluna) =>
            {
                return c1.Dados[coluna, linha];
            });

            return Resultado;
        }
        /// <summary>
        /// Hadamard
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static Matriz operator %(Matriz c1, Matriz c2)
        {
            Matriz Resultado = new Matriz(c1.Linhas, c1.Colunas);

            Resultado.Map((valor, linha, coluna) =>
            {
                return c1.Dados[linha, coluna] * c2.Dados[linha, coluna];
            });

            return Resultado;
        }
        public decimal[] ConverterParaArray()
        {
            decimal[] resultado = new decimal[this.Dados.LongLength];
            Matriz temp = this;
            int k = 0;

            for (int i = 0; i < this.Dados.GetLength(0); i++)
                for (int j = 0; j < this.Dados.GetLength(1); j++)
                    resultado[k++] = this.Dados[i, j];

            return resultado;
        }
    }
}
