using System;
using System.Linq;

namespace Saque
{
    class Program
    {
        //        new int[] { 2,10},
        //        new int[] { 5,1},
        //        new int[] { 10, 2 },
        //        new int[] { 20, 3 },
        //        new int[] { 50, 3 },
        //        new int[] { 100, 02 }

        static int[] Saque(int[][] cedulasCaixa, decimal input)
        {
            int[] resultado = null;
            var teste = cedulasCaixa.ToList();
            for (int i = 0; i < cedulasCaixa.Length; i++)
            {
                if (cedulasCaixa[i][0] == input)
                {
                    resultado = new int[] { cedulasCaixa[i][0] };
                    return resultado;
                }
            }
            teste.RemoveAll(x => x[0] > input);

            //Array atualizado com as cedulas menores  que o input
            cedulasCaixa = teste.ToArray();

            //Verificar se é possível atingir o valor com as cedulas restates
            //tirar a diferença entre o input e a cédula anterior e tentar chegar nesse valor subtraindo as cedulas
            var diferença = 0;
            diferença = (int)(input - cedulasCaixa[cedulasCaixa.Length - 1][0]);
            var diferecaOriginal = diferença;
            var indice = 1;
            while (true)
            {
                for (int i = cedulasCaixa.Length-indice; i >=0; i--)
                {
                    while (diferença >= cedulasCaixa[i][0])
                    {
                        diferença -= cedulasCaixa[i][0];
                    }
                }
                if (diferença != 0) {
                    diferença = diferecaOriginal;
                    indice++;
                }
            }


            





            return resultado;
        }



        static void Main(string[] args)
        {
            int[][] cedulas = new int[][]
            {
                new int[] { 2,10},
                new int[] { 5,1},
                new int[] { 10,2},
                new int[] { 20,3},
                new int[] { 50,3},
                new int[] { 100,02}
            };
            Console.WriteLine("Digite o valor do Saque");
            var input = decimal.Parse(Console.ReadLine());
            var result = Saque(cedulas, input);
            Console.WriteLine($"Retorno: [{string.Join(",", result)}]");
            Console.ReadKey();
        }
    }
}
