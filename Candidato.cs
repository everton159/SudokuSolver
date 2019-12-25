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
            if(this.numero!=candidato.numero)
                return this.numero - candidato.numero;

            if(this.linha!=candidato.linha)
                return this.linha - candidato.linha;
  
            if(this.coluna!=candidato.coluna)
                return this.coluna - candidato.coluna;

           if(this.casa!=candidato.casa)
                return this.casa - candidato.casa;
            
           if(this.andar!=candidato.andar)
                return this.andar - candidato.andar;

            return 0;
        }
    

    public override string ToString(){
            return  ($"Número: {this.numero} Linha: {this.linha} Coluna: {this.coluna} Casa: {this.casa} Andar: {this.andar}");
        }
   
    }
}
