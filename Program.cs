using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    partial class Program
    {
           
         static  int[,] matrix = new int[9,9]{
                     {3,8,4,9,5,7,1,0,0,},
                     {2,0,0,8,4,1,9,3,0},
                     {0,7,0,2,6,3,8,0,4},
                     {7,3,9,6,2,5,0,8,0},
                     {0,0,0,4,3,8,0,0,0},
                     {8,4,0,7,1,9,3,6,2},
                     {4,0,3,5,8,2,0,7,0},
                     {0,0,8,1,7,6,0,0,3},
                     {0,0,7,3,9,4,5,0,8},
                };
            
        static void Main(string[] args)
        {

            Console.WriteLine("Inicio de tudo");

            ImprimeMatrix();

            List<Candidato> Candidatos = new List<Candidato>();
            List<Candidato> paraAplicar = new List<Candidato>();
            for (int iteracao = 0; iteracao < 20; iteracao++)
            {
                Console.WriteLine($"Iteração :{iteracao}");

                Candidatos.Clear();
                paraAplicar.Clear();

                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int z = 1; z <= 9; z++)
                        {
                            if (!existeNaCelula(x, y, z))
                            {
                                for (int l = (x * 3); l < (x * 3) + 3; l++)
                                {
                                    if (!existeNaLinha(l, z))
                                    {
                                        for (int c = y * 3; c < (y * 3) + 3; c++)
                                        {
                                            if (!existeNaColuna(c, z))
                                                if (matrix[l, c] == 0)
                                                    Candidatos.Add(new Candidato(z, l, c, l / 3, c / 3));

                                        }
                                    }
                                }
                            }
                        }
                    }
                }



                var CandidatosCasa =
                from Candidato in Candidatos
                group Candidato by (Candidato.numero, Candidato.andar, Candidato.casa) into CandidatoGroup
                where CandidatoGroup.Count() == 1
                select new
                {
                    Numero = CandidatoGroup.Key,
                    Quantidade = CandidatoGroup.Count(),

                };


                if (CandidatosCasa.Count() < 1)
                {
                    
                    Console.WriteLine("Concluido");
                    ImprimeMatrix();
                    return;
                }





                //Converte pega os candidados novamente


                foreach (var solucao in CandidatosCasa)
                {
                    var resultado = solucao.Numero.ToTuple();
                    //Console.WriteLine()
                    paraAplicar.Add(Candidatos.Where(x => x.numero == resultado.Item1 && x.andar == resultado.Item2 && x.casa == resultado.Item3).First());
                }


                Console.WriteLine("Para Aplicar");
                foreach (Candidato candidato in paraAplicar)
                {

                    Console.WriteLine(candidato);
                    matrix[candidato.linha, candidato.coluna] = candidato.numero;
                }


                Console.WriteLine("Resultado final");
                ImprimeMatrix();

            }


        }

        private static void ImprimeMatrix()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool existeNaColuna(int coluna, int numero)
        {
            for (int i = 0; i < 9 ; i++)
            {
                if(matrix[i,coluna]==numero)
                    return true;
            }
            return false;
        }

        public static bool existeNaLinha(int linha, int numero){
            for (int i = 0; i < 9 ; i++)
            {
                if(matrix[linha,i]==numero)
                    return true;
            }
            return false;
        }

         public static bool existeNaCelula(int linha, int coluna,int numero){
           for (int i = linha*3; i < (linha*3)+3; i++)
            {
                for (int j = coluna*3; j < (coluna*3)+3; j++)
                {
                    if(matrix[i,j]==numero)                    
                        return true;
                }
            }
            return false;
        }

        






    }
}
