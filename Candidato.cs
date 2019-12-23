using System;

namespace SudokuSolver
{
        public class Candidato: IComparable<Candidato>
    {
             public int  numero,linha, coluna, casa, andar;

            public Candidato( int numero, int linha, int coluna, int casa, int andar)
            {
                this.numero= numero;
                this.linha= linha;
                this.coluna=coluna;
                this.casa= casa;
                this.andar= andar;


            }

     
   public int CompareTo(Candidato candidato)
        {
            //(Candidato)obj;
           return this.numero - candidato.numero;
        }
    

    public override string ToString(){
            return  ($"Número: {this.numero} Linha: {this.linha} Coluna: {this.coluna} Casa: {this.casa} Andar: {this.andar}");
        }
   
    }
}
