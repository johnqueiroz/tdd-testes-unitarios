using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Services
{
    public class CalculadoraImp
    {

        private List<string> listaHistorico;
        private string Data;

        
        public CalculadoraImp(string data){
            listaHistorico = new List<string>();
            Data = data;
        }


        public void inserirHistorico(int resultado){
            listaHistorico.Insert(0, "Resultado: " + resultado + "-" + "Data: " + Data);
        }

        public int Somar(int numero1, int numero2){
            int resultado = numero1 + numero2;
            inserirHistorico(resultado);
            return resultado;
        }

        public int Subtrair(int numero1, int numero2){
            int resultado = numero1 - numero2;
            inserirHistorico(resultado);
            return resultado;
        }

        public int Multiplicar(int numero1, int numero2){
            int resultado = numero1 * numero2;
            inserirHistorico(resultado);
            return resultado;
        }

        public int Dividir(int numero1, int numero2){
            int resultado = numero1 / numero2;
            inserirHistorico(resultado);
            return resultado;
        }


        public int ConversaoMilimetrosCentimetros(int numero1){
            int resultado = numero1 / 10;
            inserirHistorico(resultado);
            return resultado;
        }


        public List<string> Historico(){

            listaHistorico.RemoveRange(3, listaHistorico.Count - 3); // Mostra apenas os 3 primeiros da lista (Remove o restante).
            return listaHistorico;
        }
    }
}