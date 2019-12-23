using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    partial class Program
    {
        static  int[,] matrix = new int[9,9]{
                    {0,0,0,0,4,6,2,0,1},
                    {0,4,6,0,0,0,0,5,3},
                    {0,0,2,1,3,9,4,8,6},
                    {0,6,8,0,0,2,0,0,4},
                    {3,0,1,0,7,0,6,0,8},
                    {4,0,0,0,0,0,1,9,0},
                    {2,1,4,8,5,7,0,0,0},
                    {9,8,0,0,0,0,5,1,0},
                    {6,0,5,3,9,0,0,0,0},
                };
            
        static void Main(string[] args)
        {
            //Console.WriteLine("Candidatos Celula");

            Console.WriteLine("Inicio de tudo");
            
            for(int i =0; i < 9; i++){
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }



        List<Candidato> Candidatos =  new List<Candidato>();
        List<Candidato> paraAplicar = new List<Candidato>();
        for (int iteracao = 0;iteracao  < 10; iteracao++)
        {
            
                Candidatos.Clear();
                paraAplicar.Clear();

            
            
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        if (!existeNaCelula(x/3,y/3,j) && !existeNaColuna(y,j) && !existeNaLinha(x,j))
                        {
                            Candidatos.Add( new Candidato(j,x,y,x/3,x/3));
                            
                        }
                    }
                }
            }
            
            Console.WriteLine("Possiveis solucao");
            Candidatos.Sort();
 





//Seleciona os candidatos possíveis
            var CandidatosCasa =
            from Candidato in Candidatos
            group Candidato by (Candidato.numero,Candidato.andar, Candidato.casa) into CandidatoGroup
            where CandidatoGroup.Count() == 1
            select new
            {
              Numero = CandidatoGroup.Key,
               Quantidade = CandidatoGroup.Count(),
               
           };

          /*  if(CandidatosCasa.Count()<1)
            { 
                return;
            }
            */




//Converte pega os candidados novamente
        
            
            foreach(var solucao in CandidatosCasa){
              var resultado = solucao.Numero.ToTuple();
               paraAplicar.Add(Candidatos.Where(x => x.numero==resultado.Item1 && x.andar==resultado.Item2 && x.casa==resultado.Item3).First());
            }


            Console.WriteLine("Para Aplicar");
            foreach(Candidato candidato in paraAplicar){
                
                Console.WriteLine(candidato);
                matrix[candidato.linha, candidato.coluna]=candidato.numero;
            }

            
        Console.WriteLine("Resultado atual");
            for(int i =0; i < 9; i++){
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            

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
